using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourierManagementSystem.Areas.Admin.Controllers
{

    [Authorize]
    [Area("Admin")]
    public class AdminDasbordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
