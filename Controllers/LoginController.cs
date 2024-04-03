using Microsoft.AspNetCore.Mvc;

namespace ImportFile_excel.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Login( string user, string pass)
        {
            try
            {
                if(user.Length > 0 && pass.Length > 0)
                {

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return View();  
        }
    }
}
