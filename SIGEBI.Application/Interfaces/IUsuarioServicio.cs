using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SIGEBI.Domain.Entities.Usuario;

namespace SIGEBI.Application.Interfaces
{
    public interface IUsuarioServicio
    {
        void RegistrarUsuario(Usuario usuario);
        Usuario ObtenerPorId(int id);
        Usuario ObtenerPorCedula(string cedula);
        IEnumerable<Usuario> Listar();
    }
}