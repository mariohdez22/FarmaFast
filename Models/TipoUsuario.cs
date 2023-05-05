using System;
using System.Collections.Generic;

namespace FarmaFast.Models;

public partial class TipoUsuario
{
    public int IdtipoUsuario { get; set; }

    public string TipoUsuario1 { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
