using FarmaFast.Models;
using FarmaFast.Models.ViewModels;
using FarmaFast.Recursos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
#pragma warning disable 

namespace FarmaFast.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly FarmaFastContext _baseDatos;

        public UsuariosController(FarmaFastContext baseDatos)
        {
            _baseDatos = baseDatos;
        }

        public async Task<IActionResult> Index(string buscar)
        {
            var usuarios = await _baseDatos.Usuarios
                           .Include(eu => eu.IdestadoUsuarioNavigation)
                           .Include(tu => tu.IdtipoUsuarioNavigation)
                           .OrderByDescending(d => d.Idusuario)
                           .ToListAsync();

            if (!String.IsNullOrEmpty(buscar))
            {
                usuarios = await _baseDatos.Usuarios.Where(

                    b => b.Nombres!.Contains(buscar) ||
                         b.Dui!.Contains(buscar) ||
                         b.Correo!.Contains(buscar) ||
                         b.Celular!.Contains(buscar) ||
                         b.IdestadoUsuarioNavigation.EstadoUsuario1!.Contains(buscar) ||
                         b.IdtipoUsuarioNavigation.TipoUsuario1!.Contains(buscar)

                    ).ToListAsync();
            }

            return View(usuarios);
        }

        [HttpGet]
        public IActionResult AgregarUsuario(int IDusuario) 
        {
            UsuarioVM usuario = new UsuarioVM()
            {
                obUsuario = new Usuario(),
                listaEstado = _baseDatos.EstadoUsuarios.Select(eu => new SelectListItem()
                {
                    Text = eu.EstadoUsuario1,
                    Value = eu.IdestadoUsuario.ToString()

                }).ToList(),
                listaTipo = _baseDatos.TipoUsuarios.Select(tu => new SelectListItem() 
                { 
                
                    Text = tu.TipoUsuario1,
                    Value = tu.IdtipoUsuario.ToString()

                }).ToList()
            };

            if (IDusuario != 0)
            {
                usuario.obUsuario = _baseDatos.Usuarios.Find(IDusuario);
            }

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarUsuario(UsuarioVM usuario)
        {
            if(ModelState.IsValid)
            {
                if (usuario.obUsuario.Idusuario == 0)
                {
                    usuario.obUsuario.Contrasena = Utilidades.EncriptarClave(usuario.obUsuario.Contrasena);
                    _baseDatos.Usuarios.Add(usuario.obUsuario);
                    await _baseDatos.SaveChangesAsync();
                    TempData["MensajeCrear"] = "El usuario se agrego correctamente";
                    return RedirectToAction(nameof(AgregarUsuario));
                }
                else
                {
                    usuario.obUsuario.Contrasena = Utilidades.EncriptarClave(usuario.obUsuario.Contrasena);
                    _baseDatos.Usuarios.Update(usuario.obUsuario);
                    await _baseDatos.SaveChangesAsync();
                    TempData["MensajeActualizar"] = "El usuario se actualizo correctamente";
                    return RedirectToAction(nameof(Index));
                }
            }

            TempData["Error"] = "¡Advertencia! Campos vacios";

            usuario = new UsuarioVM()
            {
                obUsuario = new Usuario(),
                listaEstado = _baseDatos.EstadoUsuarios.Select(eu => new SelectListItem()
                {
                    Text = eu.EstadoUsuario1,
                    Value = eu.IdestadoUsuario.ToString()

                }).ToList(),
                listaTipo = _baseDatos.TipoUsuarios.Select(tu => new SelectListItem()
                {

                    Text = tu.TipoUsuario1,
                    Value = tu.IdtipoUsuario.ToString()

                }).ToList()
            };

            return View(usuario);
        }
    }
}
