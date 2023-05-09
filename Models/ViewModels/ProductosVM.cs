using Microsoft.AspNetCore.Mvc.Rendering;

namespace FarmaFast.Models.ViewModels
{
    public class ProductosVM
    {
        public Producto obProducto { get; set; }

        public List<SelectListItem> listMarca { get; set; }
        
        public List<SelectListItem> listaTipo { get; set; }

        public List<SelectListItem> listaEstado { get; set; }
    }
}
