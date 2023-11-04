using CourierManagementSystem.Areas.Shipper.Models;
using CourierManagementSystem.Entity.MasterData;
using CourierManagementSystem.Services.AuthService;
using CourierManagementSystem.Services.AuthService.Interfaces;
using CourierManagementSystem.Services.CourierManagementService.Interface;
using CourierManagementSystem.Services.CustomerUserService.Interface;
using CourierManagementSystem.Services.ShipperService;
using CourierManagementSystem.Services.ShipperService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourierManagementSystem.Areas.Shipper.Controllers
{
    [Authorize]
    [Area("Shipper")]
    public class ShipperController : Controller
    {
        private readonly IUserInfoes userInfoes;
        private readonly IShipper shipper;
        private readonly ICourierManagement courierManagement;
        public ShipperController(IUserInfoes userInfoes,IShipper shipper, ICourierManagement courierManagement)
        {
            this.shipper = shipper;
            this.userInfoes = userInfoes;
            this.courierManagement = courierManagement;


        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ShipperAssignDasbord()
        {
            return View();
        }

        public async Task<IActionResult> ShipperAssignList()
        {
            string userName = HttpContext.User.Identity.Name;
            var userInfo = await userInfoes.GetUserInfoByUser(userName);
            string shipperId = userInfo.aspnetId;
            ShipperVM model = new ShipperVM
            {
                customers = await shipper.GetShipperAssignOrderedList(shipperId)
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ShipperPickeUp(int id)
        {
            var customerData = await shipper.GetOrderInfoById(id);
            int status = 2;
            await courierManagement.UpdateCustomerStatus(id,status);
           


            ShipTracking shipModel = new ShipTracking
            {
                customerId = customerData.Id,
                ApplicationUserId = customerData.ApplicationUserId,
                ConsignmentNumber = customerData.ConsignmentNumber,
                ConsigmentStatus = 2,
                EditDateTime = DateTime.Now,
            };
            await courierManagement.SaveShipTracking(shipModel);
            return View();

        }


        public async Task<IActionResult> ShipperpickupList()
        {
            string userName = HttpContext.User.Identity.Name;
            var userInfo = await userInfoes.GetUserInfoByUser(userName);
            string shipperId = userInfo.aspnetId;
            ShipperVM model = new ShipperVM
            {
                customers = await shipper.GetShipperPickupOrderedList(shipperId)
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> ShipperDelivred(int id)
        {
            var customerData = await shipper.GetOrderInfoById(id);
            int status = 3;
            await courierManagement.UpdateCustomerStatus(id, status);



            ShipTracking shipModel = new ShipTracking
            {
                customerId = customerData.Id,
                ApplicationUserId = customerData.ApplicationUserId,
                ConsignmentNumber = customerData.ConsignmentNumber,
                ConsigmentStatus = 3,
                EditDateTime = DateTime.Now,
            };
            await courierManagement.SaveShipTracking(shipModel);
            return View();

        }

        public async Task<IActionResult> ShipperDeliveredList()
        {
            string userName = HttpContext.User.Identity.Name;
            var userInfo = await userInfoes.GetUserInfoByUser(userName);
            string shipperId = userInfo.aspnetId;
            ShipperVM model = new ShipperVM
            {
                customers = await shipper.GetShipperDeliveredOrderedList(shipperId)
            };
            return View(model);
        }


        public async Task<IActionResult> GetAllDetailsPickupByShipper()
        {
       
            ShipperVM model = new ShipperVM
            {
              customers = await shipper.GetAllDetailsPickupByShipper()
            };
            return View(model);
           
        }




    }
}
