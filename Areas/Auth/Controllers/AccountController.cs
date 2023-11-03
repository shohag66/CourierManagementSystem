using CourierManagementSystem.Areas.Auth.Models;
using CourierManagementSystem.Entity;
using CourierManagementSystem.Services.AuthService;
using CourierManagementSystem.Services.AuthService.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourierManagementSystem.Areas.Auth.Controllers
{

   // [Authorize]
    [Area("Auth")]
    public class AccountController : Controller
    {
        private ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IDbChangeService dbChangeService;
        private readonly IUserInfoes userInfoes;
        public AccountController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, 
            RoleManager<ApplicationRole> roleManager, IUserInfoes userInfoes, IDbChangeService dbChangeService)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            this.userInfoes = userInfoes;
            this.dbChangeService = dbChangeService;

        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LogInViewModel model, string? returnUrl = null)
        {

            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {

                var userInfos = await userInfoes.GetUserInfoByUser(model.Name);
                if (userInfos != null)
                {
                    if (userInfos.isActive == 1)
                    {
                        var result = await _signInManager.PasswordSignInAsync(model.Name, model.Password, model.RememberMe, lockoutOnFailure: true);
                        if (result.Succeeded)
                        {
                            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                            var userAgent = Request.Headers["User-Agent"].ToString();
                            var mechineName = Environment.MachineName;
                            UserLogHistory userLog = new UserLogHistory
                            {
                                userId = model.Name,
                                logTime = DateTime.Now,
                                status = 1,
                                ipAddress = ip,
                                pcName = mechineName,
                                browserName = userAgent
                            };

                          //  await dbChangeService.SaveUserLogHistory(userLog);
                            var userRole = await userInfoes.GetUserRoleByUserName(model.Name);
                            if (userRole == "Admin")
                            {
                                //return Redirect("/SCMRequisition/RequisitionDashbord/digDashboard");
                               // return Redirect("/SCMDashboard/Dashboard/GetDashBoardForDIG");
                                return Redirect("/Admin/AdminDasbord/Index");
                            }
                            else if (userRole == "customer")
                            {

                                return Redirect("/Home/Privacy");
                            }
                            
                            else
                            {
                                ModelState.AddModelError(string.Empty, "This User does not have any Access Pages");
                                return View(model);
                            }

                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                            return View(model);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return View(model);
                    }
                }

                else
                {
                    // If there are any ModelState errors, you can add them to the ViewData dictionary
                    ViewData["Errors"] = ModelState.Values.SelectMany(v => v.Errors);
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

    }
}
