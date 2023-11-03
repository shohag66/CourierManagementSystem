using CourierManagementSystem.Areas.Auth.Models;
using static System.Collections.Specialized.BitVector32;

namespace CourierManagementSystem.Areas.CourierManagement.Models
{
    public class CreateOrderVM
    {
      
        public string consignmentNumber { get; set; }
        public string customerName { get; set; }
        public string address { get; set; }
        public string mobile { get; set; }
        public string itemName { get; set; }
        public DateTime OrderPlacedDate { get; set; }
        public DateTime estimatedDeliveryDate { get; set; }
        public decimal quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Weaight { get; set; }
        public decimal heaight { get; set; }
        public decimal deliveryCharge { get; set; }
        public decimal dueAmount { get; set; }
        public string processedBranch { get; set; }
        public string pickupBranch { get; set; }
        public string productType { get; set; }
        public string deliveryaddress { get; set; }



    }
}
