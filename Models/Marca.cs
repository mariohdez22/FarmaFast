using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FarmaFast.Models;

public partial class Marca
{
    public int Idmarca { get; set; }

    [Required(ErrorMessage = "Nombre obligatorio")]
    public string Nombre { get; set; } = null!;

    [Required]
    public int? Idvigencia { get; set; }

    [Required]
    public int? Idestilo { get; set; }

    [Required]
    public int? Idproveedor { get; set; }

    public virtual EstiloProducto IdestiloNavigation { get; set; } = null!;

    public virtual Proveedor IdproveedorNavigation { get; set; } = null!;

    public virtual Vigencium IdvigenciaNavigation { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}
