using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.Interfaces;

namespace SIGEBI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditoriaController : ControllerBase
    {
        private readonly IAuditoriaServicio _auditoriaServicio;

        public AuditoriaController(IAuditoriaServicio auditoriaServicio)
        {
            _auditoriaServicio = auditoriaServicio;
        }

        // GET api/Auditoria?desde=2026-01-01&hasta=2026-12-31
        [HttpGet]
        public IActionResult ObtenerPorRango(DateTime desde, DateTime hasta)
        {
            var registros = _auditoriaServicio.ObtenerPorRango(desde, hasta);
            return Ok(registros);
        }
    }
}