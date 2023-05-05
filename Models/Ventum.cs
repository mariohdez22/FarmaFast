using System;
using System.Collections.Generic;

namespace FarmaFast.Models;

public partial class Ventum
{
    public int Idventa { get; set; }

    public string Codigoventa { get; set; } = null!;

    public decimal Total { get; set; }

    public decimal Subtotal { get; set; }

    public int Idusuario { get; set; }

    public string Cliente { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public virtual ICollection<DetalleVentum> DetalleVenta { get; } = new List<DetalleVentum>();

    public virtual Usuario IdusuarioNavigation { get; set; } = null!;
}
