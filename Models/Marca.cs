using System;
using System.Collections.Generic;

namespace FarmaFast.Models;

public partial class Marca
{
    public int Idmarca { get; set; }

    public string Nombre { get; set; } = null!;

    public int Idvigencia { get; set; }

    public int Idestilo { get; set; }

    public int Idproveedor { get; set; }

    public virtual EstiloProducto ObEstilo { get; set; } = null!;

    public virtual Proveedor ObProveedor { get; set; } = null!;

    public virtual Vigencia ObVigencia { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}
