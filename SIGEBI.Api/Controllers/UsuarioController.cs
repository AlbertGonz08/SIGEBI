using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Application.Services;
using SIGEBI.Domain.Entities.Biblioteca;
using SIGEBI.Domain.Entities.Usuario;
using SIGEBI.Domain.Enums;
using System.Linq.Expressions;

namespace SIGEBI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServicio _usuarioServicio;

        public UsuarioController(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var usuarios = _usuarioServicio.Listar();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var usuario = _usuarioServicio.ObtenerPorId(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpGet("cedula/{cedula}")]
        public IActionResult ObtenerPorCedula(string cedula)
        {
            var usuario = _usuarioServicio.ObtenerPorCedula(cedula);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }


        [HttpPost]
        public IActionResult Registrar([FromBody] UsuarioDto dto)
        {
            try
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
                _usuarioServicio.RegistrarUsuario(dto);
                return Ok("Usuario registrado correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
    
