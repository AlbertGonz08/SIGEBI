using SIGEBI.Application.DTOs;
using SIGEBI.Domain.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.Mappers
{
    public static class UsuarioMapper
    {
        public static UsuarioDto ToDto(Usuario usuario)
        {
            return new UsuarioDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Cedula = usuario.Cedula,
                Estado = usuario.Estado.ToString(),
                TipoUsuario = usuario.TipoUsuarioId.ToString(),
            };
        }
    }
}