using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.Services;

namespace SIGEBI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PenalizacionController : ControllerBase
    {
        private readonly PenalizacionServicio _penalizacionServicio;

        public PenalizacionController(PenalizacionServicio penalizacionServicio)
        {
            _penalizacionServicio = penalizacionServicio;
        }

        // GET api/penalizaciones/usuario/5
        [HttpGet("usuario/{usuarioId}")]
        public IActionResult ObtenerActivasPorUsuario(int usuarioId)
        {
            var penalizaciones = _penalizacionServicio.ObtenerActivasPorUsuario(usuarioId);
            return Ok(penalizaciones);
        }

        // POST api/penalizaciones/resolver/5
        [HttpPost("resolver/{penalizacionId}")]
        public IActionResult ResolverPenalizacion(int penalizacionId)
        {
            try
            {
                _penalizacionServicio.ResolverPenalizacion(penalizacionId);
                return Ok("Penalización resuelta correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}