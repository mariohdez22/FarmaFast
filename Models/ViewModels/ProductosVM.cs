using Microsoft.AspNetCore.Mvc.Rendering;

namespace FarmaFast.Models.ViewModels
{
    public class ProductosVM
    {
        public Producto producto { get; set; }
        
        public List<SelectListItem> listaTipo { get; set; }
    }
}
