using CourierManagementSystem.Areas.CourierManagement.Models;
using CourierManagementSystem.Entity.MasterData;
using CourierManagementSystem.Services.AuthService;
using CourierManagementSystem.Services.CourierManagementService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics.Metrics;

namespace CourierManagementSystem.Areas.CourierManagement.Controllers
{
    [Area("CourierManagement")]
    public class CourierManagementDashBord : Controller
    {
        private readonly ICourierManagement courierManagement;
        public CourierManagementDashBord(ICourierManagement courierManagement)
        {
            this.courierManagement = courierManagement;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {

            var Orderd = await courierManagement.GetAllCustomer();
            int Cordred = 0;
            Cordred = Orderd.Where(x => Convert.ToDateTime(x.OrderPlacedDate).ToString("MM") == Convert.ToDateTime(DateTime.Now).ToString("MM")).Count();
            string idateM = Convert.ToDateTime(DateTime.Now).ToString("MM");
            string idatey = Convert.ToDateTime(DateTime.Now).ToString("yy");
            string ConsignmentNumber = "";
            ConsignmentNumber = "Con" + '-' + idateM + idatey + String.Format("{0:00000}", (Cordred + 1));


            ViewBag.ConsignmentNumber = ConsignmentNumber;


            CreateOrderVM model = new CreateOrderVM
            {
                userInfoes = await courierManagement.GetAllShipper()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderVM model)
        {

            Customer customer = new Customer
            {
                Name = model.customerName,
                Address = model.address,
                MobileNumber = model.mobile,
                ConsignmentNumber = model.consignmentNumber,
                OrderPlacedDate = model.OrderPlacedDate,
                EstimatedDeliveryDate = model.estimatedDeliveryDate,
                Consignmentstatus=1,//Ordered place
                isActive = 1,
                ApplicationUserId=model.ShipperId,
                remarks = "Test"
                

            };
            var customerId = await courierManagement.SaveUserCustomer(customer);


            OrderDetails orderDetails = new OrderDetails
            {
                customerId = customerId,
                itemQty = model.quantity,
                unitRate = model.UnitPrice,
                weaight = model.Weaight,
                heaight = model.heaight,
                deliveryCharge = model.deliveryCharge,
                dueAmount = model.dueAmount,
                processedBranch = model.processedBranch,
                pickupBranch = model.pickupBranch,
                productType = "Test",
                remarks = "Test"


            };
            await courierManagement.SaveOrderDetails(orderDetails);

            ShipTracking shipModel = new ShipTracking
            {
                customerId = customerId,
                ApplicationUserId = model.ShipperId,
                ConsignmentNumber = model.consignmentNumber,
                ConsigmentStatus = 1,
                EditDateTime = DateTime.Now,
            };
            await courierManagement.SaveShipTracking(shipModel);

            return View();
        }


        public async Task<IActionResult> GetAllOrderPlacedList(CourierManagementListVM model)
        {
            CourierManagementListVM courier = new CourierManagementListVM
            {
                PlacedOrderList = await courierManagement.GetAllOrderedPlacedList()

            };
            return View(courier);
        }


       


    }
    
}
