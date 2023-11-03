using Microsoft.AspNetCore.Mvc;

namespace CourierManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDasbordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
