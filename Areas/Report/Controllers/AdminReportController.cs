using Microsoft.AspNetCore.Mvc;

namespace CourierManagementSystem.Areas.Report.Controllers
{
    public class AdminReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
