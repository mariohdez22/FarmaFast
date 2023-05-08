using Microsoft.AspNetCore.Mvc;

namespace FarmaFast.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AgregarProducto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AgregarProducto(int hola)
        {
            return View();
        }
    }
}
