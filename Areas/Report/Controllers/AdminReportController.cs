using Microsoft.AspNetCore.Mvc;

namespace CourierManagementSystem.Areas.Report.Controllers
{
    public class AdminReportController : Controller
    {
        public async Task<IActionResult> GetAllOrderedDetailsData(DateTime startDate, DateTime endDate)
        {
            ViewBag.FromDate = Convert.ToDateTime(startDate).ToString("dd MMM yyyy");
            ViewBag.ToDate = Convert.ToDateTime(endDate).ToString("dd MMM yyyy");
         
            return View();


        }
    }
}
