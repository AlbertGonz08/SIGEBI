using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.Services;

namespace SIGEBI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamoController : ControllerBase
    {
        private readonly PrestamoServicio _prestamoServicio;

        public PrestamoController(PrestamoServicio prestamoServicio)
        {
            _prestamoServicio = prestamoServicio;
        }

        // POST api/prestamos — solicita un préstamo
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