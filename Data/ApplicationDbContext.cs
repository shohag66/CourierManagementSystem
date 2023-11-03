using CourierManagementSystem.Entity;
using CourierManagementSystem.Entity.MasterData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        this._httpContextAccessor = httpContextAccessor;
    }
    public DbSet<UserLogHistory> UserLogHistories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }



    #region Settings Configs
    public override int SaveChanges()
    {
        AddTimestamps();
        return base.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        AddTimestamps();
        return await base.SaveChangesAsync();
    }

    private void AddTimestamps()
    {

        var entities = ChangeTracker.Entries().Where(x => x.Entity is Bases && (x.State == EntityState.Added || x.State == EntityState.Modified));

        var currentUsername = !string.IsNullOrEmpty(_httpContextAccessor?.HttpContext?.User?.Identity?.Name)
            ? _httpContextAccessor.HttpContext.User.Identity.Name
            : "Anonymous";

        foreach (var entity in entities)
        {
            if (entity.State == EntityState.Added)
            {
                ((Bases)entity.Entity).createdAt = DateTime.Now;
                ((Bases)entity.Entity).createdBy = currentUsername;
            }
            else
            {
                entity.Property("createdAt").IsModified = false;
                entity.Property("createdBy").IsModified = false;
                ((Bases)entity.Entity).updatedAt = DateTime.Now;
                ((Bases)entity.Entity).updatedBy = currentUsername;
            }

            #region changelog
            int sessionId = 0;
            DateTime myDate1 = new DateTime(1970, 1, 9, 0, 0, 00);
            DateTime myDate2 = DateTime.Now;
            TimeSpan myDateResult;
            myDateResult = myDate2 - myDate1;
            double seconds = myDateResult.TotalSeconds;
            sessionId = Convert.ToInt32(seconds);

            string entityName = entity.Entity.GetType().Name;
            string entityState = entity.State.ToString();
            if (entityName != "UserLogHistory")
            {

                var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json");

                var configuration = builder.Build();

                using (var db = new SqlConnection(configuration.GetConnectionString("CourierManagementConnection")))
                {
                    db.Open();

                    var entityMember = entity.Members;
                    var value = entity.Members.Count();
                    var entityinfo = entity.Entity.GetType();
                    var entityVal = entity.Entity;
                    string customAttributeName = string.Empty;
                    var fieldName = entityinfo.GetProperties();
                    for (int i = 0; i < fieldName.Count(); i++)
                    {
                        var columnName = fieldName[i].Name;
                        string colType = fieldName[i].PropertyType.ToString();
                        var custmAttribute = fieldName[i].GetCustomAttributesData();
                        if (custmAttribute.Count() >= 1)
                            customAttributeName = custmAttribute.FirstOrDefault().AttributeType.Name;

                        //if (colType.Contains("CourierManagementSystem") || customAttributeName == "NotMappedAttribute")
                        //{

                        //}
                        //else
                        //{

                        //    //var valueName = entity?.Property(columnName)?.CurrentValue?.ToString();
                        //    //valueName = valueName?.Replace("'", "''");
                        //    //string Tmp1 = $"INSERT INTO DbChangeHistories (entityName,fieldName,fieldValue,entityState,sessionId,createdBy,createdAt) VALUES('{entityName}','{columnName}','{valueName}','{entityState}','{sessionId}','{currentUsername}','{DateTime.Now}');";
                        //    //SqlCommand cmd1 = new SqlCommand(Tmp1, db);
                        //    //cmd1.ExecuteScalar();
                        //}

                    }
                    db.Close();
                }

            }

            #endregion
        }
    }
    #endregion
}