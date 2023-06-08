using FarmaFast.Models;
using FarmaFast.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
#pragma warning disable

namespace FarmaFast.Controllers
{
    [Authorize]
    public class VentasController : Controller
    {
        private readonly FarmaFastContext _baseDatos;

        public VentasController(FarmaFastContext baseDatos)
        {
            _baseDatos = baseDatos;
        }

        public IActionResult IndexVenta()
        {
            List<VentasVM> ventas = _baseDatos.Venta.Include(dv => dv.DetalleVenta)
            .OrderByDescending(d => d.Fecha)
            .Select(v => new VentasVM()
            {
                Codigoventa = v.Codigoventa,
                Total = v.Total,
                Subtotal = v.Subtotal,
                NombreUsuarios = v.IdusuarioNavigation.Nombres,
                Cliente = v.Cliente,
                Fecha = v.Fecha.ToString(),
                DetalleVentas = _baseDatos.DetalleVenta
                .Where(dv => dv.Idventa == v.Idventa)
                .Select(dv => new DetalleVentasVM()
                {
                    Idproducto = dv.Idproducto,
                    Productos = dv.IdproductoNavigation.Nombre,
                    Cantidad = dv.Cantidad,
                    Precio = dv.Precio,
                    Subtotal = Math.Round(dv.Cantidad * dv.Precio, 2)

                }).ToList()

            }).ToList();            

            return View(ventas);
        }

//----------------------------------------------------------------------------------------------------

        [HttpGet]
        public IActionResult GenerarVenta()
        {
            //--------------------------------------------------

            ClaimsPrincipal claimuser = HttpContext.User;
            string nombreUsuario = "";
            string idUsuario = "";
            string imagenUsuario = "";

            if (claimuser.Identity.IsAuthenticated)
            {
                nombreUsuario = claimuser.Claims.Where(c => c.Type == ClaimTypes.Name)
                                .Select(c => c.Value).SingleOrDefault();

                idUsuario = claimuser.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;

                imagenUsuario = claimuser.Claims.FirstOrDefault(c => c.Type == "Imagen")?.Value;
            }

            ViewData["nombreUsuario"] = nombreUsuario;
            ViewData["idUsuario"] = idUsuario;
            ViewData["imagenUsuario"] = imagenUsuario;

            //--------------------------------------------------

            return View();
        }

        public IActionResult buscarProducto(string busqueda)
        {
            VentasVM ventas = new VentasVM() 
            { 
                ProductosDetalle = _baseDatos.Productos
                .Where(b => b.Nombre!.Contains(busqueda) && b.Cantidad > 0)
                .Select(b => new ProductosDetalleVM() 
                { 
                    
                    Idproducto = b.Idproducto,
                    Nombre = b.Nombre,
                    Precio = b.Precio,
                    Cantidad = b.Cantidad,
                    Imagen = b.Imagen

                }).ToList()
            };

            return Json(new {datos = ventas});
        }

        [HttpPost]
        public IActionResult GenerarVenta(VentasVM oVentaVM)
        {
            try
            {
                Ventum ventum = new Ventum();
                ventum.Codigoventa = oVentaVM.Codigoventa;
                ventum.Total = oVentaVM.Total;
                ventum.Subtotal = oVentaVM.Subtotal;
                ventum.Idusuario = oVentaVM.Idusuario;
                ventum.Cliente = oVentaVM.Cliente;
                ventum.Fecha = DateTime.Now;
                _baseDatos.Add(ventum);
                _baseDatos.SaveChanges();

                foreach (var dvm in oVentaVM.DetalleVentas)
                {
                    DetalleVentum dv = new DetalleVentum();
                    dv.Idventa = ventum.Idventa;
                    dv.Idproducto = dvm.Idproducto;
                    dv.Precio = dvm.Precio;
                    dv.Cantidad = dvm.Cantidad;

                    var producto = _baseDatos.Productos.Find(dvm.Idproducto);
                    producto.Cantidad -= dvm.Cantidad;

                    _baseDatos.Productos.Update(producto);
                    _baseDatos.Add(dv);
                }

                _baseDatos.SaveChanges();
                TempData["MensajeCrear"] = "La venta se agrego correctamente";
                return RedirectToAction(nameof(GenerarVenta));

            }
            catch (Exception ex)
            {
                return View(ex);
            }

            
        }

    }
}
