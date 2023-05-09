using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FarmaFast.Models;

public partial class Producto
{
    [Key]
    public int Idproducto { get; set; }
    [Required(ErrorMessage = "Nombre obligatorio")]
    public string Nombre { get; set; } = null!; // franja principal
    [Required(ErrorMessage = "Precio obligatorio")]
    public decimal Precio { get; set; } // contenido 3
    [Required(ErrorMessage = "Cantidad obligatorio")]
    public int Cantidad { get; set; } // contenido 4
    [Required(ErrorMessage = "Imagen obligatorio")]
    public string Imagen { get; set; } = null!; // contenido 1
    [Required(ErrorMessage = "Marca obligatorio")]
    public int Idmarca { get; set; } // contenido 2
    [Required(ErrorMessage = "Tipo obligatorio")]
    public int IdtipoProducto { get; set; } // franja principal // contenido 6
    [Required(ErrorMessage = "Estado obligatorio")]
    public int IdestadoProducto { get; set; } // contenido 5

    public virtual ICollection<DetalleVentum> DetalleVenta { get; } = new List<DetalleVentum>();

    public virtual EstadoProducto IdestadoProductoNavigation { get; set; } = null!;

    public virtual Marca IdmarcaNavigation { get; set; } = null!;

    public virtual TipoProducto IdtipoProductoNavigation { get; set; } = null!;
}
