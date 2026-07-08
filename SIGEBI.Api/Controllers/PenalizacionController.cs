using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.Services;
using SIGEBI.Application.Interfaces;

namespace SIGEBI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DevolucionController : ControllerBase
    {
        private readonly IDevolucionServicio _devolucionServicio;

        public DevolucionController(IDevolucionServicio devolucionServicio)
        {
            _devolucionServicio = devolucionServicio;
        }

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