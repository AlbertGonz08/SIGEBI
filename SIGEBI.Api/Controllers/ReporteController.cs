using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.Interfaces;

namespace SIGEBI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReporteController : ControllerBase
    {
        private readonly IReporteServicio _reporteServicio;

        public ReporteController(IReporteServicio reporteServicio)
        {
            _reporteServicio = reporteServicio;
        }

        // GET api/Reporte/prestamos?desde=2026-01-01&hasta=2026-12-31
        [HttpGet("prestamos")]
        public IActionResult ObtenerPrestamosPorRango(DateTime desde, DateTime hasta)
        {
            var prestamos = _reporteServicio.ObtenerPrestamosPorRango(desde, hasta);
            return Ok(prestamos);
        }

        // GET api/Reporte/vencidos
        [HttpGet("vencidos")]
        public IActionResult ObtenerVencidos()
        {
            var vencidos = _reporteServicio.ObtenerVencidos();
            return Ok(vencidos);
        }

        // GET api/Reporte/penalizaciones
        [HttpGet("penalizaciones")]
        public IActionResult ObtenerPenalizacionesActivas()
        {
            var penalizaciones = _reporteServicio.ObtenerPenalizacionesActivas();
            return Ok(penalizaciones);
        }
    }
}