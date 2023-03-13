using Microsoft.AspNetCore.Mvc;

namespace FarmaFast.Controllers
{
    public class VentasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
