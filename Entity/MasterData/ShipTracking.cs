namespace CourierManagementSystem.Entity.MasterData
{
    public class ShipTracking:Bases
    {
        public int? customerId { get; set; }
        public Customer customer { get; set; }
        //Shipper User LInk
        public string? ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string? ConsignmentNumber { get; set; }
        public DateTime EditDateTime { get; set; }
        public int? ConsigmentStatus { get; set; }
    }
}
