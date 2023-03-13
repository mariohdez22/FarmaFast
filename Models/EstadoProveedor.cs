using System;
using System.Collections.Generic;

namespace FarmaFast.Models;

public partial class EstadoProveedor
{
    public int IdestadoProveedor { get; set; }

    public string EstadoProveedor1 { get; set; } = null!;

    public virtual ICollection<Proveedor> Proveedors { get; } = new List<Proveedor>();
}
