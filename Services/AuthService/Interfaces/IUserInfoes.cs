using CourierManagementSystem.Areas.Auth.Models;

namespace CourierManagementSystem.Services.AuthService.Interfaces
{
    public interface IUserInfoes
    {
        Task<AspNetUsersViewModel> GetUserInfoByUser(string userName);
        Task<string> GetUserRoleByUserName(string userName);
    }
}
