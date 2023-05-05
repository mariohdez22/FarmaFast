using System;
using System.Collections.Generic;

namespace FarmaFast.Models;

public partial class DetalleVentum
{
    public int IddetalleVenta { get; set; }

    public int Idventa { get; set; }

    public int Idproducto { get; set; }

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public virtual Producto IdproductoNavigation { get; set; } = null!;

    public virtual Ventum IdventaNavigation { get; set; } = null!;
}
