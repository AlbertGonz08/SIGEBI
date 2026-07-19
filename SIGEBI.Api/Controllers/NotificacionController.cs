using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.Interfaces;

namespace SIGEBI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacionController : ControllerBase
    {
        private readonly INotificacionServicio _notificacionServicio;

        public NotificacionController(INotificacionServicio notificacionServicio)
        {
            _notificacionServicio = notificacionServicio;
        }

        [HttpGet("usuario/{usuarioId}")]
        public IActionResult ObtenerPorUsuario(int usuarioId)
        {
            var notificaciones = _notificacionServicio.ObtenerPorUsuario(usuarioId);
            var resultado = notificaciones.Select(n => new
            {
                n.Id,
                n.UsuarioId,
                Tipo = n.Tipo.ToString(),
                n.Mensaje,
                n.FechaGeneracion,
                n.FueEnviada
            });
            return Ok(resultado);
        }
    }
}