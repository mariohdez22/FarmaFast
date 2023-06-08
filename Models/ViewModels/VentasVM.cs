#pragma warning disable
namespace FarmaFast.Models.ViewModels
{
    public class VentasVM
    {
        public string Codigoventa { get; set; } = null!;

        public decimal Total { get; set; }

        public decimal Subtotal { get; set; }

        public int Idusuario { get; set; }

        public string NombreUsuarios { get; set; } // inner join

        public string Cliente { get; set; } = null!;

        public string Fecha { get; set; }

        public List<ProductosDetalleVM> ProductosDetalle { get; set;}

        public List<DetalleVentasVM> DetalleVentas { get; set; }

    }
}
