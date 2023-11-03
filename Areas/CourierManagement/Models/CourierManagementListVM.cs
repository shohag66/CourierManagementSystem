using CourierManagementSystem.Entity.MasterData;

namespace CourierManagementSystem.Areas.CourierManagement.Models
{
    public class CourierManagementListVM
    {
        public IEnumerable<Customer> PlacedOrderList { get; set; }
    }
}
