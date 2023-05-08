using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FarmaFast.Models;

public partial class Usuario
{
    [Key]
    public int Idusuario { get; set; }

    [Required(ErrorMessage = "Nombre obligatorio")]
    public string Nombres { get; set; } = null!;

    [Required(ErrorMessage = "Correo obligatorio")]
    public string Correo { get; set; } = null!;

    [Required(ErrorMessage = "Celular obligatorio")]
    public string Celular { get; set; } = null!;

    [Required(ErrorMessage = "Dui obligatorio")]
    public string Dui { get; set; } = null!;

    [Required]
    public int? IdestadoUsuario { get; set; }

    [Required]
    public int? IdtipoUsuario { get; set; }

    [Required(ErrorMessage = "Contraseña obligatoria")]
    public string Contrasena { get; set; } = null!;

    [Required(ErrorMessage = "Imagen obligatoria")]
    public string Imagen { get; set; } = null!;

    public virtual EstadoUsuario IdestadoUsuarioNavigation { get; set; } = null!;

    public virtual TipoUsuario IdtipoUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
