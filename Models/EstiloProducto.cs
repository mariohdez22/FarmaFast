using System;
using System.Collections.Generic;

namespace FarmaFast.Models;

public partial class EstiloProducto
{
    public int Idestilo { get; set; }

    public string EstiloProducto1 { get; set; } = null!;

    public virtual ICollection<Marca> Marcas { get; } = new List<Marca>();
}
