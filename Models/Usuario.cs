using System;
using System.Collections.Generic;

namespace FarmaFast.Models;

public partial class Usuario
{
    public int Idusuario { get; set; }

    public string Nombres { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Celular { get; set; } = null!;

    public string Dui { get; set; } = null!;

    public int IdestadoUsuario { get; set; }

    public int IdtipoUsuario { get; set; }

    public string Contrasena { get; set; } = null!;

    public string Imagen { get; set; } = null!;

    public virtual EstadoUsuario IdestadoUsuarioNavigation { get; set; } = null!;

    public virtual TipoUsuario IdtipoUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Ventum> Venta { get; } = new List<Ventum>();
}
