using CourierManagementSystem.Areas.CustomerUser.Models;

using CourierManagementSystem.Services.AuthService.Interfaces;
using CourierManagementSystem.Services.CourierManagementService;
using CourierManagementSystem.Services.CourierManagementService.Interface;
using CourierManagementSystem.Services.CustomerUserService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourierManagementSystem.Areas.CustomerUser.Controllers
{
    [Authorize]
    [Area("CustomerUser")]
    public class CustomerUserController : Controller
    {
        private readonly ICustomerUser customerUser;
        private readonly ICourierManagement courierManagement;
        public CustomerUserController(ICustomerUser customerUser, ICourierManagement courierManagement)
        {
            this.customerUser = customerUser;
            this.courierManagement = courierManagement;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CustomerAssignDasbord()
        {
            return View();
        }

        public async Task<IActionResult> CustomerOrderTraking()
        {
            return View();
        }


        public async Task<IActionResult> GetAllCustomerUsers()
        {
            var data = new CustomerManagementVM
            {
                customers = await courierManagement.GetAllCustomer()
            };
            return View(data);
        }


        #region Customer Track Data Load API
        [HttpGet]
        public async Task<IActionResult> GetDataByConsignmentNumber(string ConsignmentNumbers)
        {
            var data = await customerUser.GetTrackingData(ConsignmentNumbers);
            return Json(data);
        }
        #endregion

    }
}
