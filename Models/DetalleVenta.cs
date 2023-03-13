using System;
using System.Collections.Generic;

namespace FarmaFast.Models;

public partial class DetalleVenta
{
    public int IddetalleVenta { get; set; }

    public int Idventa { get; set; }

    public int Idproducto { get; set; }

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public virtual Producto ObProducto { get; set; } = null!;

    public virtual Venta ObVenta { get; set; } = null!;
}
