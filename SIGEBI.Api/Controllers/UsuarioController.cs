using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.Services;
using SIGEBI.Domain.Entities.Usuario;

namespace SIGEBI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioServicio _usuarioServicio;

        public UsuarioController(UsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        // GET api/usuarios  lista todos los usuarios
        [HttpGet]
        public IActionResult Listar()
        {
            var usuarios = _usuarioServicio.Listar();
            return Ok(usuarios);
        }

        // GET api/usuarios/5
        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var usuario = _usuarioServicio.ObtenerPorId(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        // GET api/usuarios/cedula/00100000000
        [HttpGet("cedula/{cedula}")]
        public IActionResult ObtenerPorCedula(string cedula)
        {
            var usuario = _usuarioServicio.ObtenerPorCedula(cedula);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }
    }
}