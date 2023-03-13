using System;
using System.Collections.Generic;

namespace FarmaFast.Models;

public partial class Producto
{
    public int Idproducto { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public int Cantidad { get; set; }

    public string Imagen { get; set; } = null!;

    public int Idmarca { get; set; }

    public int IdtipoProducto { get; set; }

    public int IdestadoProducto { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; } = new List<DetalleVenta>();

    public virtual EstadoProducto ObEstadoProducto { get; set; } = null!;

    public virtual Marca ObMarca { get; set; } = null!;

    public virtual TipoProducto ObTipoProducto { get; set; } = null!;
}
