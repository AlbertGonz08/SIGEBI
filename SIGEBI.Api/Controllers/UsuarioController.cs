using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.Services;
using SIGEBI.Domain.Entities.Usuario;
using SIGEBI.Application.Interfaces;

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
    }
}