using CourierManagementSystem.Entity.MasterData;

namespace CourierManagementSystem.Services.CustomerUserService.Interface
{
    public interface ICustomerUser
    {
        Task<IEnumerable<ShipTracking>> GetTrackingData(string ConsignmentNumber);
    }
}
