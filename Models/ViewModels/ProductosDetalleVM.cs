namespace FarmaFast.Models.ViewModels
{
    public class ProductosDetalleVM
    {

        public int Idproducto { get; set; }

        public string Nombre { get; set; } = null!;

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }

        public string Imagen { get; set; } = null!;

    }
}
