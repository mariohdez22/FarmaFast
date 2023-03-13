using System;
using System.Collections.Generic;

namespace FarmaFast.Models;

public partial class EstadoProducto
{
    public int IdestadoProducto { get; set; }

    public string EstadoProducto1 { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}
