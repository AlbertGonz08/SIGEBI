using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.Services;
using SIGEBI.Application.Interfaces;

namespace SIGEBI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamoServicio _prestamoServicio;

        public PrestamoController(IPrestamoServicio prestamoServicio)
        {
            _prestamoServicio = prestamoServicio;
        }

        [HttpPost]
        public IActionResult SolicitarPrestamo(int usuarioId, int recursoId)
        {
            try
            {
                _prestamoServicio.SolicitarPrestamo(usuarioId, recursoId);
                return Ok("Préstamo registrado correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}