using FarmaFast.Models;
using FarmaFast.Models.ViewModels;
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

        public async Task<IActionResult> Index()
        {
            var usuarios = await _baseDatos.Usuarios.Include(eu => eu.IdestadoUsuarioNavigation)
                                                    .Include(tu => tu.IdtipoUsuarioNavigation)
                                                    .ToListAsync();

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
                    _baseDatos.Usuarios.Add(usuario.obUsuario);
                    await _baseDatos.SaveChangesAsync();
                    TempData["MensajeCrear"] = "El usuario se agrego correctamente";
                    return RedirectToAction(nameof(AgregarUsuario));
                }
                else
                {
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
