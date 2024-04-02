using Microsoft.AspNetCore.Mvc;

namespace ImportFile_excel.Controllers.Admin
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return PartialView("Views/Shared/Admin/_LoginLayout.cshtml");
        }
    }
}
