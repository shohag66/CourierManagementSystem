namespace CourierManagementSystem.Entity.MasterData
{
    public class OrderDetails : Bases
    {
        public int? customerId { get; set; }
        public Customer customer { get; set; }
        public decimal? itemQty { get; set; }
        public decimal? unitRate { get; set; }
        public decimal? weaight { get; set; }
        public decimal? heaight { get; set; }
        public decimal? deliveryCharge { get; set; }
        public decimal? totalAmount { get; set; }
        public decimal? dueAmount { get; set; }
        public string? processedBranch { get; set; }
        public string? pickupBranch { get; set; }
        public string productType { get; set; }
        public string remarks { get; set; }
    }
}
