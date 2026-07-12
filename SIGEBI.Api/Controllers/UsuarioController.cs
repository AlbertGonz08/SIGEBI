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
            var dtos = usuarios.Select(u => new UsuarioDto
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Correo = u.Correo,
                Cedula = u.Cedula,
                Estado = u.Estado.ToString(),
                TipoUsuario = u.TipoUsuarioId == 1 ? "Estudiante" : "Docente"
            });
            return Ok(dtos);
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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
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
    
