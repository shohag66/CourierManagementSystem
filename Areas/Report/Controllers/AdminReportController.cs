using CourierManagementSystem.Helpers;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System;

namespace CourierManagementSystem.Areas.Report.Controllers
{
    [Authorize]
    [Area("Report")]
    public class AdminReportController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly string? rootPath;
        private readonly MyPDF myPDF;

        public AdminReportController(IWebHostEnvironment hostingEnvironment,IConverter converter)
        {
            myPDF = new MyPDF(hostingEnvironment, converter);
            rootPath = hostingEnvironment.ContentRootPath;
            this._hostingEnvironment = hostingEnvironment;


        }


        public async Task<IActionResult> GetAllOrderedDetailsData(DateTime startDate, DateTime endDate)
        {
            ViewBag.FromDate = Convert.ToDateTime(startDate).ToString("dd MMM yyyy");
            ViewBag.ToDate = Convert.ToDateTime(endDate).ToString("dd MMM yyyy");
         
            return View();


        }

        [AllowAnonymous]
        public IActionResult GetAllOrderedDetailsPDF(DateTime startDate, DateTime endDate)
        {
            string? scheme = Request.Scheme;
            var host = Request.Host.ToString();
            string? url = scheme + "://" + host + "/Report/AdminReport/GetAllOrderedDetailsView?startDate=" + startDate + "&endDate=" + endDate;

            string? fileName;
           
            string? status = myPDF .GeneratePDF(out fileName, url);

            if (status != "done")
            {
                return Content("<h1>Something Went Wrong</h1>");
            }

            var stream = new FileStream(rootPath + "/wwwroot/pdf/" + fileName, FileMode.Open);
            return new FileStreamResult(stream, "application/pdf");
        }


        public IActionResult GetAllOrderedDetailsView(DateTime startDate, DateTime endDate)
        {
            return View();
        }

    }
}
