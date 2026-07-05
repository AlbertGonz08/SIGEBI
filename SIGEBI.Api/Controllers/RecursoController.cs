using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.Services;

namespace SIGEBI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecursoController : ControllerBase
    {
        private readonly RecursoServicio _recursoServicio;

        public RecursoController(RecursoServicio recursoServicio)
        {
            _recursoServicio = recursoServicio;
        }

        // GET api/recursos  devuelve todo el catálogo
        [HttpGet]
        public IActionResult ObtenerCatalogo()
        {
            var recursos = _recursoServicio.ObtenerCatalogo();
            return Ok(recursos);
        }

        // GET api/recursos/disponibles  obtener solo los disponibles
        [HttpGet("disponibles")]
        public IActionResult ObtenerDisponibles()
        {
            var recursos = _recursoServicio.ObtenerDisponibles();
            return Ok(recursos);
        }

        // GET api/recursos/5
        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var recurso = _recursoServicio.ObtenerPorId(id);
            if (recurso == null) return NotFound();
            return Ok(recurso);
        }
    }
}