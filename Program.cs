using CourierManagementSystem.Data;
using CourierManagementSystem.Entity;
using CourierManagementSystem.Services.AuthService.Interfaces;
using CourierManagementSystem.Services.AuthService;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using CourierManagementSystem.Services.CourierManagementService.Interface;
using CourierManagementSystem.Services.CourierManagementService;
using CourierManagementSystem.Services.ShipperService;
using CourierManagementSystem.Services.ShipperService.Interface;
using CourierManagementSystem.Services.CustomerUserService.Interface;
using CourierManagementSystem.Services.CustomerUserService;

var builder = WebApplication.CreateBuilder(args);

#region Configure Services

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("CourierManagementConnection")));

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
   .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.AddMemoryCache();
builder.Services.AddHttpContextAccessor();


builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddControllersWithViews(option =>
{
    option.MaxModelBindingCollectionSize = int.MaxValue;
}).AddJsonOptions(options => {
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = false;

}).AddRazorRuntimeCompilation();

builder.Services.AddRazorPages();
#endregion

#region Auth Related Settings
builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 4;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromHours(1);

    options.LoginPath = "/Auth/Account/Login";
    options.AccessDeniedPath = "/Auth/Account/AccessDenied";
    options.SlidingExpiration = true;
});

builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
    options.Limits.MaxRequestBodySize = 1073741824; // Set your desired value here
});

builder.Services.Configure<FormOptions>(o =>
{
    o.ValueCountLimit = int.MaxValue;
    o.BufferBodyLengthLimit = int.MaxValue;
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = long.MaxValue; // <-- !!! long.MaxValue
    o.MultipartBoundaryLengthLimit = int.MaxValue;
    o.MultipartHeadersCountLimit = int.MaxValue;
    o.MultipartHeadersLengthLimit = int.MaxValue;
});

#endregion

builder.Services.AddScoped<IDbChangeService, DbChangeService>();
builder.Services.AddScoped<IUserInfoes, UserInfoes>();
builder.Services.AddScoped<ICourierManagement, CourierManagement>();
builder.Services.AddScoped<IShipper, Shipper>();
builder.Services.AddScoped<ICustomerUser, CustomerUserService>();
#region Configuration
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

#endregion

