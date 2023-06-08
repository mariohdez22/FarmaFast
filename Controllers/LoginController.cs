using Microsoft.AspNetCore.Mvc;
using FarmaFast.Servicios.Contrato;
using FarmaFast.Recursos;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using FarmaFast.Models;
using System.Drawing;
#pragma warning disable

namespace FarmaFast.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioServices _usuarioServicio;

        public LoginController(IUsuarioServices usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
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

        [HttpPost]
        public async Task<IActionResult> Index(string correo, string clave)
        {
            Usuario usuarioEncontrado = await _usuarioServicio.GetUsuario(correo, Utilidades.EncriptarClave(clave));

            if(usuarioEncontrado == null)
            {
                ViewData["Mensaje"] = "No se pudo encontrar el usuario";
                return View();
            }

            List<TipoUsuario> tipoUsuario = await _usuarioServicio.GetTipo(usuarioEncontrado.Idusuario);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuarioEncontrado.Nombres),
                new Claim("Id", usuarioEncontrado.Idusuario.ToString()),
                new Claim("Imagen", usuarioEncontrado.Imagen)
            };

            if (tipoUsuario != null && tipoUsuario.Count > 0)
            {
                foreach (var tipos in tipoUsuario)
                {
                    claims.Add(new Claim(ClaimTypes.Role, tipos.TipoUsuario1));
                }
            }

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                              CookieAuthenticationDefaults.AuthenticationScheme,
                              new ClaimsPrincipal(claimsIdentity),
                              properties
                              );

            return RedirectToAction("Index", "Home");

        }
    }
}
