using CourierManagementSystem.Areas.Auth.Models;
using CourierManagementSystem.Entity.MasterData;

namespace CourierManagementSystem.Services.ShipperService.Interface
{
    public interface IShipper
    {
        Task<IEnumerable<Customer>> GetShipperAssignOrderedList(string shipperId);
        Task<Customer> GetOrderInfoById(int Id);
        Task<IEnumerable<Customer>> GetShipperPickupOrderedList(string shipperId);
        Task<IEnumerable<Customer>> GetShipperDeliveredOrderedList(string shipperId);
    }
}
