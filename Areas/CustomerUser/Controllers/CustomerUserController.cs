using CourierManagementSystem.Services.AuthService.Interfaces;
using CourierManagementSystem.Services.CustomerUserService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CourierManagementSystem.Areas.CustomerUser.Controllers
{
    [Area("CustomerUser")]
    public class CustomerUserController : Controller
    {
        private readonly ICustomerUser customerUser;

        public CustomerUserController(ICustomerUser customerUser)
        {
            this.customerUser = customerUser;  
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
