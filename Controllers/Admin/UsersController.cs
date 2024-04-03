using ImportFile_excel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImportFile_excel.Controllers.Admin
{
    public class UsersController : Controller
    {
        private readonly CustDbcontext _dataContext;
        private readonly ILogger<HomeController> _logger;
        public UsersController(CustDbcontext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        // create 
        

    }
}
