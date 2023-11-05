using DinkToPdf.Contracts;
using DinkToPdf;

namespace CourierManagementSystem.Helpers
{
    public class MyPDF
    {
        private readonly string rootPath;
        private readonly IConverter _converter;

        public MyPDF(IWebHostEnvironment hostingEnvironment, IConverter converter)
        {
            this.rootPath = hostingEnvironment.ContentRootPath + "/wwwroot/pdf/";
            _converter = converter;
        }

        public string GeneratePDF(out string fileName, string url)
        {
            string status = "done";
            fileName = "Document_" + DateTime.Now.ToString("yyyy-MM-dd_HH-ss") + ".pdf";

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings() { Top = 12, Bottom = 9, Left = 14, Right = 14 },
                    Out = rootPath+fileName
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HeaderSettings = { FontName = "Arial", FontSize = 3, Right = "", Line = false, HtmUrl=""},
                        Page =url,
                    }
                }
            };

            try
            {
                _converter.Convert(doc);
            }
            catch (Exception e)
            {
                status = e.Message;
            }
            return status;
        }
    }
}
