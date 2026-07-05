using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.Services;

namespace SIGEBI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DevolucionController : ControllerBase
    {
        private readonly DevolucionServicio _devolucionServicio;

        public DevolucionController(DevolucionServicio devolucionServicio)
        {
            _devolucionServicio = devolucionServicio;
        }

        // POST api/devoluciones  para registrar una devolución
        [HttpPost]
        public IActionResult RegistrarDevolucion(int prestamoId)
        {
            try
            {
                _devolucionServicio.RegistrarDevolucion(prestamoId);
                return Ok("Devolución registrada correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}