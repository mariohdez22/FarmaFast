namespace FarmaFast.Models
{
    public partial class MarcaProducto
    {
        public int IdMarca { get; set; }

        public string Marca1 { get; set; } = null!;

        public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
    }
}
