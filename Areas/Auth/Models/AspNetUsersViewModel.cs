namespace CourierManagementSystem.Areas.Auth.Models
{
    public class AspNetUsersViewModel
    {
        public string? aspnetId { get; set; }
        public string? UserName { get; set; }

        public int UserId { get; set; }

        public string? Email { get; set; }

        public int? UserTypeId { get; set; }
        public string? Code { get; set; }
    
        public int? isActive { get; set; }
        public string? roleId { get; set; }
        public string? roleName { get; set; }
        public string? Id { get; set; }

    }
}
