using CourierManagementSystem.Entity;

namespace CourierManagementSystem.Services.AuthService.Interfaces
{
    public interface IDbChangeService
    {
        Task<int> SaveUserLogHistory(UserLogHistory userLogHistory);

        Task<IEnumerable<UserLogHistory>> GetAllUserLogHistory();

        Task<IEnumerable<UserLogHistory>> GetUserLogHistoryByUser(string userName);
    }
}
