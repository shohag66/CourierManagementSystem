using CourierManagementSystem.Entity.MasterData;

namespace CourierManagementSystem.Areas.Shipper.Models
{
    public class ShipperVM
    {
        public IEnumerable<Customer> customers { get; set; }
    }
}
