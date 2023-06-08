using Microsoft.EntityFrameworkCore;
using FarmaFast.Models;

namespace FarmaFast.Servicios.Contrato
{
    public interface IUsuarioServices
    {
        Task<Usuario> GetUsuario(string correo, string clave);

        Task<List<TipoUsuario>> GetTipo(int idPersonal);
    }
}
