using Microsoft.AspNetCore.Mvc;

namespace FarmaFast.Controllers
{
    public class ProveedoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AgregarProveedor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AgregarProveedor(int hola)
        {
            return View();
        }

    }   
}
