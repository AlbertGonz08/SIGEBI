using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.Services;
using SIGEBI.Application.Interfaces;

namespace SIGEBI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecursoController : ControllerBase
    {
        private readonly IRecursoServicio _recursoServicio;

        public RecursoController(IRecursoServicio recursoServicio)
        {
            _recursoServicio = recursoServicio;
        }

        [HttpGet]
        public IActionResult ObtenerCatalogo()
        {
            var recursos = _recursoServicio.ObtenerCatalogo();
            return Ok(recursos);
        }

        [HttpGet("disponibles")]
        public IActionResult ObtenerDisponibles()
        {
            var recursos = _recursoServicio.ObtenerDisponibles();
            return Ok(recursos);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var recurso = _recursoServicio.ObtenerPorId(id);
            if (recurso == null) return NotFound();
            return Ok(recurso);
        }
    }
}