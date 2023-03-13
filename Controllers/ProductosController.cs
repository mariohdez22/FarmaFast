using Microsoft.AspNetCore.Mvc;

namespace FarmaFast.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
