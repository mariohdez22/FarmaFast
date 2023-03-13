using Microsoft.AspNetCore.Mvc;

namespace FarmaFast.Controllers
{
    public class ProveedoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
