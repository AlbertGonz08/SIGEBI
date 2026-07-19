using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities.Auditoria;
using SIGEBI.Domain.Entities.Prestamo;
using SIGEBI.Domain.Enums;
using SIGEBI.Domain.Repository;
using SIGEBI.Domain.Rules;

namespace SIGEBI.Application.Services
{
    public class PrestamoServicio : IPrestamoServicio
    {
        private readonly IPrestamoRepository _prestamoRepo;
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IRecursoRepository _recursoRepo;
        private readonly IPenalizacionRepository _penalizacionRepo;
        private readonly IAuditoriaRepository _auditoriaRepo;
        private readonly INotificacionServicio _notificacionServicio;

        public PrestamoServicio(IPrestamoRepository prestamoRepo, IUsuarioRepository usuarioRepo,
            IRecursoRepository recursoRepo, IPenalizacionRepository penalizacionRepo,
            IAuditoriaRepository auditoriaRepo, INotificacionServicio notificacionServicio)
        {
            _prestamoRepo = prestamoRepo;
            _usuarioRepo = usuarioRepo;
            _recursoRepo = recursoRepo;
            _penalizacionRepo = penalizacionRepo;
            _auditoriaRepo = auditoriaRepo;
            _notificacionServicio = notificacionServicio;
        }

        public void SolicitarPrestamo(int usuarioId, int recursoId)
        {
            var usuario = _usuarioRepo.ObtenerPorId(usuarioId);
            var penalizaciones = _penalizacionRepo.ObtenerActivasPorUsuario(usuarioId);
            var prestamosActivos = _prestamoRepo.ObtenerActivosPorUsuario(usuarioId);
            var recurso = _recursoRepo.ObtenerPorId(recursoId);

            if (!ReglasDeAcceso.PuedeRealizarPrestamo(usuario, penalizaciones))
                throw new Exception("El usuario no puede realizar préstamos.");

            if (ReglasDePrestamo.UsuarioAlcanzoLimite(usuario, prestamosActivos.Count()))
                throw new Exception("El usuario alcanzó su límite de préstamos.");

            if (!ReglasDePrestamo.RecursoPuedeSerPrestado(recurso))
                throw new Exception("El recurso no está disponible.");

            var prestamo = new Prestamo
            {
                UsuarioId = usuarioId,
                RecursoId = recursoId,
                FechaInicio = DateTime.Now,
                FechaLimite = ReglasDePrestamo.CalcularFechaLimite(usuario),
                Estado = EstadoPrestamo.Activo
            };

            _prestamoRepo.Guardar(prestamo);

            recurso.Estado = EstadoRecurso.Prestado;
            _recursoRepo.Actualizar(recurso);

            // Notificar al usuario que el préstamo fue aprobado
            _notificacionServicio.Enviar(usuarioId, TipoNotificacion.PrestamoAprobado,
                $"Tu préstamo fue aprobado. Fecha límite: {prestamo.FechaLimite:dd/MM/yyyy}");

            // Auditoría
            _auditoriaRepo.Registrar(new RegistroAuditoria
            {
                TipoAccion = "RegistroPrestamo",
                UsuarioSistema = usuarioId,
                FechaHora = DateTime.Now,
                Descripcion = $"Préstamo registrado — Usuario {usuarioId}, Recurso {recursoId}",
                TablaAfectada = "Prestamo",
                RegistroId = prestamo.Id
            });
        }
    }
}