using Microsoft.AspNetCore.Identity;

namespace CourierManagementSystem.Entity
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string? roleName) : base(roleName)
        {

        }
    }
}
