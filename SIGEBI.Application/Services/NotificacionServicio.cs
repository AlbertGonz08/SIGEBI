using SIGEBI.Domain.Entities.Notificacion;
using SIGEBI.Domain.Enums;
using SIGEBI.Domain.Repository;

public class NotificacionServicio
{
    private readonly INotificacionRepository _notificacionRepo;

    public NotificacionServicio(INotificacionRepository notificacionRepo)
    {
        _notificacionRepo = notificacionRepo;
    }

    // Guardar una notificación para el usuario
    public void Enviar(int usuarioId, TipoNotificacion tipo, string mensaje)
    {
        var notificacion = new Notificacion
        {
            UsuarioId = usuarioId,
            Tipo = tipo,
            Mensaje = mensaje,
            FechaGeneracion = DateTime.Now,
            FueEnviada = true
        };

        _notificacionRepo.Guardar(notificacion);
    }

    public IEnumerable<Notificacion> ObtenerPorUsuario(int usuarioId)
    {
        return _notificacionRepo.ObtenerPorUsuario(usuarioId);
    }
}