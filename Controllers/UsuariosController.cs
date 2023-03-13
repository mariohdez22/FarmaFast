using Microsoft.AspNetCore.Mvc;

namespace FarmaFast.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
