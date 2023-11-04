using CourierManagementSystem.Entity.MasterData;

namespace CourierManagementSystem.Areas.CustomerUser.Models
{
    public class CustomerManagementVM
    {
        public IEnumerable<Customer> customers { get; set; }
    }
}
