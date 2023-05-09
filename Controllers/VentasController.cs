using Microsoft.AspNetCore.Mvc;

namespace FarmaFast.Controllers
{
    public class VentasController : Controller
    {
        public IActionResult IndexVenta()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GenerarVenta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GenerarVenta(int hola)
        {
            return View();
        }

    }
}
