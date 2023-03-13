using System;
using System.Collections.Generic;

namespace FarmaFast.Models;

public partial class EstadoUsuario
{
    public int IdestadoUsuario { get; set; }

    public string EstadoUsuario1 { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
