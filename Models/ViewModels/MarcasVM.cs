using Microsoft.AspNetCore.Mvc.Rendering;
#pragma warning disable

namespace FarmaFast.Models.ViewModels
{
    public class MarcasVM
    {
        public Marca obMarca { get; set; }

        public List<SelectListItem> listaEstado { get; set; }

        public List<SelectListItem> listaEstilo { get; set; }

        public List<SelectListItem> listaProveedores { get; set; }

    }
}
