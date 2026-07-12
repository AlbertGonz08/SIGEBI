using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.Interfaces;
using SIGEBI.Application.DTOs;
using SIGEBI.Domain.Entities.Biblioteca;
using SIGEBI.Domain.Enums;

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

        [HttpPost]
        public IActionResult Registrar([FromBody] Recurso recurso)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _recursoServicio.RegistrarRecurso(recurso);
                return Ok("Recurso registrado correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}