using FarmaFast.Models;
using FarmaFast.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FarmaFast.Controllers
{
    public class ProductosController : Controller
    {
        private readonly FarmaFastContext _basedatos;

        public ProductosController(FarmaFastContext basedatos)
        {
            _basedatos = basedatos;
        }
        public async Task<IActionResult> Index()
        {
            var productos = await _basedatos.Productos.Include(tu => tu.IdestadoProductoNavigation).Include(eu => eu.IdtipoProductoNavigation).Include(si => si.IdmarcaNavigation).ToListAsync();
            return View(productos);
        }
        [HttpGet]
        public IActionResult AgregarProducto(int IdProducto)
        {
            ProductosVM productos = new ProductosVM()
            {
                obProducto = new Producto(),
                listaTipo = _basedatos.TipoProductos.Select(eu => new SelectListItem()
                {
                    Text = eu.TipoProducto1,
                    Value = eu.IdtipoProducto.ToString()

                }).ToList(),
                listaEstado = _basedatos.EstadoProductos.Select(tu => new SelectListItem()
                {

                    Text = tu.EstadoProducto1,
                    Value = tu.IdestadoProducto.ToString()

                }).ToList(),
                listMarca = _basedatos.Marcas.Select(si => new SelectListItem()
                {

                    Text = si.Nombre,
                    Value = si.Idmarca.ToString()

                }).ToList()
            };

            if (IdProducto != 0)
            {
                productos.obProducto = _basedatos.Productos.Find(IdProducto);
            }

            return View(productos);
        }
    

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarProducto(ProductosVM productos)
        {
            if (ModelState.IsValid)
            {
                if (productos.obProducto.Idproducto == 0)
                {
                    _basedatos.Productos.Add(productos.obProducto);
                    await _basedatos.SaveChangesAsync();
                    TempData["MensajeCrear"] = "El producto se agrego correctamente";
                    return RedirectToAction(nameof(AgregarProducto));
                }
                else
                {
                    _basedatos.Productos.Update(productos.obProducto);
                    await _basedatos.SaveChangesAsync();
                    TempData["MensajeActualizar"] = "El producto se actualizo correctamente";
                    return RedirectToAction(nameof(Index));
                }
            }

            TempData["Error"] = "¡Advertencia! Campos vacios";

            productos = new ProductosVM()
            {
                obProducto = new Producto(),
                listaEstado = _basedatos.EstadoProductos.Select(tu => new SelectListItem()
                {
                    Text = tu.EstadoProducto1,
                    Value = tu.IdestadoProducto.ToString()

                }).ToList(),
                listaTipo = _basedatos.TipoProductos.Select(eu => new SelectListItem()
                {

                    Text = eu.TipoProducto1,
                    Value = eu.IdtipoProducto.ToString()

                }).ToList(),
                listMarca = _basedatos.Marcas.Select(si => new SelectListItem()
                {

                    Text = si.Nombre,
                    Value = si.Idmarca.ToString()

                }).ToList()
            };

            return View(productos);
        }
            
     }
        

    
}

