using System;
using System.Collections.Generic;

namespace FarmaFast.Models;

public partial class TipoProducto
{
    public int IdtipoProducto { get; set; }

    public string TipoProducto1 { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}
