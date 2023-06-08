#pragma warning disable

namespace FarmaFast.Models.ViewModels
{
    public class DetalleVentasVM
    {
        public int Idproducto { get; set; }

        public string Productos { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public decimal Subtotal { get; set; }
    }
}
