using Microsoft.AspNetCore.Mvc;

namespace ImportFile_excel.Controllers.Admin
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
