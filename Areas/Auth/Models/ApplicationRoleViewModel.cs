namespace CourierManagementSystem.Areas.Auth.Models
{
    public class ApplicationRoleViewModel
    {
        public string? RoleId { get; set; }
        public string? PreRoleId { get; set; }
        public string[]? roleIdList { get; set; }

        public string? userId { get; set; }

        public string? userName { get; set; }

        public string? RoleName { get; set; }

    }
}
