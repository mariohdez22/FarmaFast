using FarmaFast.Models;
using FarmaFast.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
#pragma warning disable 

namespace FarmaFast.Controllers
{
    public class MarcasController : Controller
    {
        private readonly FarmaFastContext _baseDatos;

        public MarcasController(FarmaFastContext baseDatos)
        {
            _baseDatos = baseDatos;
        }

        public async Task<IActionResult> Index(string buscar)
        {
            var marcas = await _baseDatos.Marcas
                         .Include(v => v.IdvigenciaNavigation)
                         .Include(ep => ep.IdestiloNavigation)
                         .Include(p => p.IdproveedorNavigation)
                         .ToListAsync();

            if (!String.IsNullOrEmpty(buscar))
            {
                marcas = await _baseDatos.Marcas.Where(

                    b => b.Nombre!.Contains(buscar) ||
                         b.IdvigenciaNavigation.EstadoVigencia!.Contains(buscar) ||
                         b.IdestiloNavigation.EstiloProducto1!.Contains(buscar) ||
                         b.IdproveedorNavigation.Nombre!.Contains(buscar)

                    ).ToListAsync();
            }

            return View(marcas);
        }

        //---------------------------------------------------------------------------------

        [HttpGet]
        public IActionResult AgregarMarca(int IDmarca)
        {

            MarcasVM marcas = new MarcasVM()
            {
                obMarca = new Marca(),
                listaEstado = _baseDatos.Vigencia.Select(v => new SelectListItem()
                {
                    Text = v.EstadoVigencia,
                    Value = v.Idvigencia.ToString()

                }).ToList(),
                listaEstilo = _baseDatos.EstiloProductos.Select(ep => new SelectListItem()
                { 
                    Text = ep.EstiloProducto1,
                    Value = ep.Idestilo.ToString()

                }).ToList(),
                listaProveedores = _baseDatos.Proveedors.Select(p => new SelectListItem() 
                { 
                    Text = p.Nombre,
                    Value = p.Idproveedor.ToString()

                }).ToList()
            };

            if (IDmarca != 0)
            {
                marcas.obMarca = _baseDatos.Marcas.Find(IDmarca);    
            }

            return View(marcas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarMarca(MarcasVM marcas)
        {
            if (ModelState.IsValid)
            {
                if (marcas.obMarca.Idmarca == 0)
                {
                    _baseDatos.Marcas.Add(marcas.obMarca);
                    await _baseDatos.SaveChangesAsync();
                    TempData["MensajeCrear"] = "La marca se agrego correctamente";
                    return RedirectToAction(nameof(AgregarMarca));
                }
                else
                {
                    _baseDatos.Marcas.Update(marcas.obMarca);
                    await _baseDatos.SaveChangesAsync();
                    TempData["MensajeActualizar"] = "La marca se actualizo correctamente";
                    return RedirectToAction(nameof(Index));
                }
            }

            TempData["Error"] = "¡Advertencia! Campos vacios";

            marcas = new MarcasVM()
            {
                obMarca = new Marca(),
                listaEstado = _baseDatos.Vigencia.Select(v => new SelectListItem()
                {
                    Text = v.EstadoVigencia,
                    Value = v.Idvigencia.ToString()

                }).ToList(),
                listaEstilo = _baseDatos.EstiloProductos.Select(ep => new SelectListItem()
                {
                    Text = ep.EstiloProducto1,
                    Value = ep.Idestilo.ToString()

                }).ToList(),
                listaProveedores = _baseDatos.Proveedors.Select(p => new SelectListItem()
                {
                    Text = p.Nombre,
                    Value = p.Idproveedor.ToString()

                }).ToList()
            };

            return View(marcas);

        }
    }
}
