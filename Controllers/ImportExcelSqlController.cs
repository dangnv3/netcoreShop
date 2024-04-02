using ClosedXML.Excel;
using ImportFile_excel.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ImportFile_excel.Controllers
{
    public class ImportExcelSqlController : Controller
    {
        private IWebHostEnvironment _environment;
        private readonly IConvertDate _customer;
        public ImportExcelSqlController(IWebHostEnvironment environment, IConvertDate customer)
        {
            _environment = environment;
            _customer = customer;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Index(IFormFile fromFiles)
        {
            string path = _customer.Documentupload(fromFiles);
            DataTable dt = _customer.ConvertDataTable(path);
            _customer.ImportConvert(dt);
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult ExporttoExcel()
        {
            var arraylist = _customer.ExportCustomer();

            using (XLWorkbook xl = new XLWorkbook())
            {
                xl.Worksheets.Add(arraylist);

                using (MemoryStream mstream = new MemoryStream())
                {
                    xl.SaveAs(mstream);
                    return File(mstream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Customer.xlsx");
                }
            }
        }
    }
}
