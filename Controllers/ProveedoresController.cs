using FarmaFast.Models;
using FarmaFast.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FarmaFast.Controllers
{
    public class ProveedoresController : Controller
    {
        private readonly FarmaFastContext _baseDatos;

        public ProveedoresController(FarmaFastContext baseDatos)
        {
            _baseDatos = baseDatos;
        }
        public async Task<IActionResult> Index()
        {
            var proveedores = await _baseDatos.Proveedors.Include(eu => eu.IdestadoProveedorNavigation)
                                                    .ToListAsync();
            return View(proveedores);
        }

        [HttpGet]
        public IActionResult AgregarProveedor(int IDproveedor)
        {
            ProveedorVM proveedor = new ProveedorVM()
            {
                obProveedor = new Proveedor(),
                listaEstado = _baseDatos.EstadoProveedors.Select(eu => new SelectListItem()
                {
                    Text = eu.EstadoProveedor1,
                    Value = eu.IdestadoProveedor.ToString()

                }).ToList()                
            };

            if (IDproveedor != 0)
            {
                proveedor.obProveedor = _baseDatos.Proveedors.Find(IDproveedor);
            }

            return View(proveedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarProveedor(ProveedorVM proveedor)
        {
            if (ModelState.IsValid)
            {
                if (proveedor.obProveedor.Idproveedor == 0)
                {
                    _baseDatos.Proveedors.Add(proveedor.obProveedor);
                    await _baseDatos.SaveChangesAsync();
                    TempData["MensajeCrear"] = "El proveedor se agrego correctamente";
                    return RedirectToAction(nameof(AgregarProveedor));
                }
                else
                {
                    _baseDatos.Proveedors.Update(proveedor.obProveedor);
                    await _baseDatos.SaveChangesAsync();
                    TempData["MensajeActualizar"] = "El proveedor se actualizo correctamente";
                    return RedirectToAction(nameof(Index));
                }
            }

            TempData["Error"] = "¡Advertencia! Campos vacios";

            proveedor = new ProveedorVM()
            {
                obProveedor = new Proveedor(),
                listaEstado = _baseDatos.EstadoProveedors.Select(tu => new SelectListItem()
                {
                    Text = tu.EstadoProveedor1,
                    Value = tu.IdestadoProveedor.ToString()

                }).ToList()               
            };

            return View(proveedor);
        }

    }   
}
