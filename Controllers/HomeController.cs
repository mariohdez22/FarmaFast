using FarmaFast.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
#pragma warning disable

namespace FarmaFast.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ClaimsPrincipal claimuser = HttpContext.User;
            string nombreUsuario = "";
            string idUsuario = "";
            string imagenUsuario = "";
            string tipoUsuario = "";

            if (claimuser.Identity.IsAuthenticated)
            {
                nombreUsuario = claimuser.Claims.Where(c => c.Type == ClaimTypes.Name)
                                .Select(c => c.Value).SingleOrDefault();

                idUsuario = claimuser.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;

                imagenUsuario = claimuser.Claims.FirstOrDefault(c => c.Type == "Imagen")?.Value;

                tipoUsuario = claimuser.Claims.Where(t => t.Type == ClaimTypes.Role).Select(c => c.Value).SingleOrDefault();
            }

            ViewData["nombreUsuario"] = nombreUsuario;
            ViewData["idUsuario"] = idUsuario;
            ViewData["imagenUsuario"] = imagenUsuario;
            ViewData["tipoUsuario"] = tipoUsuario;

            return View();
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            
            return RedirectToAction("Index", "Login");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(/*new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }*/);
        }
    }
}