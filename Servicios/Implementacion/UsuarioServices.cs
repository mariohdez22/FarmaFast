using Microsoft.EntityFrameworkCore;
using FarmaFast.Models;
using FarmaFast.Servicios.Contrato;
using System.Drawing.Text;
using System.Text;
#pragma warning disable

namespace FarmaFast.Servicios.Implementacion
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly FarmaFastContext _baseDatos;

        public UsuarioServices(FarmaFastContext baseDatos)
        {
            _baseDatos = baseDatos;
        }

        public async Task<Usuario> GetUsuario(string correo, string clave)
        {
            Usuario usuarioEncontrado = await _baseDatos.Usuarios
                                        .Where(u => u.Correo == correo && u.Contrasena == clave)
                                        .FirstOrDefaultAsync();
            return usuarioEncontrado;
        }

        public async Task<List<TipoUsuario>> GetTipo(int idUsuario)
        {
            var tipos = await _baseDatos.Usuarios
                        .Where(u => u.Idusuario == idUsuario)
                        .Join(_baseDatos.TipoUsuarios,
                        u => u.IdtipoUsuario,
                        t => t.IdtipoUsuario,
                        (u, t) => t) 
                        .ToListAsync();

            return tipos;
        }
    }
}
