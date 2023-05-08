using Microsoft.AspNetCore.Mvc.Rendering;

namespace FarmaFast.Models.ViewModels
{
    public class UsuarioVM
    {
        public Usuario obUsuario {  get; set; }

        public List<SelectListItem> listaEstado { get; set; }
        public List<SelectListItem> listaTipo { get; set; }
    }
}
