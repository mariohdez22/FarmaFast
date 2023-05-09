using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FarmaFast.Models;

public partial class Proveedor
{
    [Key]
    public int Idproveedor { get; set; }

    [Required(ErrorMessage = "Correo obligatorio")]
    public string Correo { get; set; } = null!;

    [Required(ErrorMessage = "Dui obligatorio")]
    public string Dui { get; set; } = null!;

    [Required(ErrorMessage = "Celular obligatorio")]
    public string Celular { get; set; } = null!;

    [Required]
    public int IdestadoProveedor { get; set; }

    [Required(ErrorMessage = "Nombre obligatorio")]
    public string Nombre { get; set; } = null!;

    public virtual EstadoProveedor IdestadoProveedorNavigation { get; set; } = null!;

    public virtual ICollection<Marca> Marcas { get; } = new List<Marca>();
}
