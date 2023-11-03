namespace CourierManagementSystem.Entity.MasterData
{
    public class Customer:Bases
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? MobileNumber { get; set; }
        public string? ConsignmentNumber { get; set; }
        public DateTime? OrderPlacedDate { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public int? Consignmentstatus { get; set; }  //
        public int? isActive { get; set; }
        public string remarks { get; set; }
    }
}
