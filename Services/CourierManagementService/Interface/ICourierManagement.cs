using CourierManagementSystem.Entity;
using CourierManagementSystem.Entity.MasterData;

namespace CourierManagementSystem.Services.CourierManagementService.Interface
{
    public interface ICourierManagement
    {
        Task<int> SaveUserCustomer(Customer customer);

        Task<IEnumerable<Customer>> GetAllCustomer();

        Task<int> SaveOrderDetails(OrderDetails orderDetails);

        Task<IEnumerable<OrderDetails>> GetAlLOrderDetails();
        Task<IEnumerable<Customer>> GetAllOrderedPlacedList();
        Task<IEnumerable<ApplicationUser>> GetAllShipper();

    }
}
