using SIGEBI.Application.Interfaces;
using SIGEBI.Application.DTOs;
using SIGEBI.Domain.Entities.Usuario;
using SIGEBI.Domain.Enums;
using SIGEBI.Domain.Repository;

namespace SIGEBI.Application.Services
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUsuarioRepository _usuarioRepo;

        public UsuarioServicio(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        public void RegistrarUsuario(UsuarioDto dto)
        {
            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Cedula = dto.Cedula,
                Correo = dto.Correo,
                Contrasena = dto.Contrasena,
                TipoUsuarioId = dto.TipoUsuarioId,
                Estado = EstadoUsuario.Activo,
                Carrera = dto.Carrera,
                Departamento = dto.Departamento,
                FechaRegistro = DateTime.Now
            };
            _usuarioRepo.Guardar(usuario);
        }

        public Usuario ObtenerPorId(int id) => _usuarioRepo.ObtenerPorId(id);
        public Usuario ObtenerPorCedula(string cedula) => _usuarioRepo.ObtenerPorCedula(cedula);
        public IEnumerable<Usuario> Listar() => _usuarioRepo.Listar();
    }
}