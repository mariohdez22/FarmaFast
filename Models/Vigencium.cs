using System;
using System.Collections.Generic;

namespace FarmaFast.Models;

public partial class Vigencium
{
    public int Idvigencia { get; set; }

    public string EstadoVigencia { get; set; } = null!;

    public virtual ICollection<Marca> Marcas { get; } = new List<Marca>();
}
