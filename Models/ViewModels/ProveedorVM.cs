using Microsoft.AspNetCore.Mvc.Rendering;

namespace FarmaFast.Models.ViewModels
{
    public class ProveedorVM
    {
        public Proveedor obProveedor { get; set; }

        public List<SelectListItem> listaEstado { get; set; }
    }
}