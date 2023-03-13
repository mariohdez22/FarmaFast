using Microsoft.AspNetCore.Mvc;

namespace FarmaFast.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
