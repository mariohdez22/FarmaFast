using Microsoft.AspNetCore.Mvc;

namespace FarmaFast.Controllers
{
    public class MarcasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AgregarMarca()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AgregarMarca(int hola)
        {
            return View();
        }
    }
}
