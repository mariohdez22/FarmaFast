using System;
using System.Collections.Generic;

namespace FarmaFast.Models;

public partial class Producto
{
    public int Idproducto { get; set; }

    public string Nombre { get; set; } = null!; // franja principal

    public decimal Precio { get; set; } // contenido 3

    public int Cantidad { get; set; } // contenido 4

    public string Imagen { get; set; } = null!; // contenido 1

    public int Idmarca { get; set; } // contenido 2

    public int IdtipoProducto { get; set; } // franja principal // contenido 6

    public int IdestadoProducto { get; set; } // contenido 5

    public virtual ICollection<DetalleVentum> DetalleVenta { get; } = new List<DetalleVentum>();

    public virtual EstadoProducto IdestadoProductoNavigation { get; set; } = null!;

    public virtual Marca IdmarcaNavigation { get; set; } = null!;

    public virtual TipoProducto IdtipoProductoNavigation { get; set; } = null!;
}
