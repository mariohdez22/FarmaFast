using System;
using System.Collections.Generic;

namespace FarmaFast.Models;

public partial class Venta
{
    public int Idventa { get; set; }

    public string Codigoventa { get; set; } = null!;

    public decimal Total { get; set; }

    public decimal Subtotal { get; set; }

    public int Idusuario { get; set; }

    public string Cliente { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; } = new List<DetalleVenta>();

    public virtual Usuario ObUsuario { get; set; } = null!;
}
