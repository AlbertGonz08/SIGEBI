using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGEBI.Application.DTOs;
using SIGEBI.Domain.Entities.Usuario;

namespace SIGEBI.Application.Interfaces
{
    public interface IUsuarioServicio
    {
        public void RegistrarUsuario(UsuarioDto usuarioDto);
        Usuario ObtenerPorId(int id);
        Usuario ObtenerPorCedula(string cedula);
        IEnumerable<Usuario> Listar();
        void ActualizarUsuario(int id, UsuarioDto dto);
    }
}