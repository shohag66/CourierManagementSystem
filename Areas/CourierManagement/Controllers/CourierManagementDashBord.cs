using CourierManagementSystem.Areas.CourierManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourierManagementSystem.Areas.CourierManagement.Controllers
{
    [Area("CourierManagement")]
    public class CourierManagementDashBord : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateOrder()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateOrder(CreateOrderVM model)
        {

            return View();
        }

    }
}
