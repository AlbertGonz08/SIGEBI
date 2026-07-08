using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.Services;

using SIGEBI.Application.Interfaces;

namespace SIGEBI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PenalizacionController : ControllerBase
    {
        private readonly IPenalizacionServicio _penalizacionServicio;

        public PenalizacionController(IPenalizacionServicio penalizacionServicio)
        {
            _penalizacionServicio = penalizacionServicio;
        }

        [HttpGet("usuario/{usuarioId}")]
        public IActionResult ObtenerActivasPorUsuario(int usuarioId)
        {
            var penalizaciones = _penalizacionServicio.ObtenerActivasPorUsuario(usuarioId);
            return Ok(penalizaciones);
        }

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