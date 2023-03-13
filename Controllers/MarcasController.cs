using Microsoft.AspNetCore.Mvc;

namespace FarmaFast.Controllers
{
    public class MarcasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
