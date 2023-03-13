using System;
using System.Collections.Generic;

namespace FarmaFast.Models;

public partial class Proveedor
{
    public int Idproveedor { get; set; }

    public string Correo { get; set; } = null!;

    public string Dui { get; set; } = null!;

    public string Celular { get; set; } = null!;

    public int IdestadoProveedor { get; set; }

    public virtual EstadoProveedor ObEstadoProveedor { get; set; } = null!;

    public virtual ICollection<Marca> Marcas { get; } = new List<Marca>();
}
