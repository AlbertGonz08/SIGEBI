using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.DTOs;
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

        // GET api/Recurso/buscar?titulo=clean&autor=martin&categoriaId=1
        [HttpGet("buscar")]
        public IActionResult Buscar(string? titulo, string? autor, int? categoriaId)
        {
            var recursos = _recursoServicio.ObtenerCatalogo();

            if (!string.IsNullOrWhiteSpace(titulo))
                recursos = recursos.Where(r => r.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(autor))
                recursos = recursos.Where(r => r.Autor.Contains(autor, StringComparison.OrdinalIgnoreCase));

            if (categoriaId.HasValue)
                recursos = recursos.Where(r => r.CategoriaId == categoriaId.Value);

            return Ok(recursos);
        }
        // DELETE api/Recurso/5
        [HttpDelete("{id}")]
        public IActionResult DarDeBaja(int id)
        {
            try
            {
                _recursoServicio.DarDeBaja(id);
                return Ok("Recurso dado de baja correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Registrar([FromBody] RecursoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _recursoServicio.RegistrarRecurso(dto);
                return Ok("Recurso registrado correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}