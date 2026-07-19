using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities.Auditoria;
using SIGEBI.Domain.Entities.Penalizacion;
using SIGEBI.Domain.Enums;
using SIGEBI.Domain.Repository;
using SIGEBI.Domain.Rules;

namespace SIGEBI.Application.Services
{
    public class DevolucionServicio : IDevolucionServicio
    {
        private readonly IPrestamoRepository _prestamoRepo;
        private readonly IRecursoRepository _recursoRepo;
        private readonly IPenalizacionRepository _penalizacionRepo;
        private readonly IAuditoriaRepository _auditoriaRepo;
        private readonly INotificacionServicio _notificacionServicio;

        public DevolucionServicio(IPrestamoRepository prestamoRepo, IRecursoRepository recursoRepo,
            IPenalizacionRepository penalizacionRepo, IAuditoriaRepository auditoriaRepo,
            INotificacionServicio notificacionServicio)
        {
            _prestamoRepo = prestamoRepo;
            _recursoRepo = recursoRepo;
            _penalizacionRepo = penalizacionRepo;
            _auditoriaRepo = auditoriaRepo;
            _notificacionServicio = notificacionServicio;
        }

        public void RegistrarDevolucion(int prestamoId)
        {
            var prestamo = _prestamoRepo.ObtenerPorId(prestamoId);
            var fechaDevolucion = DateTime.Now;

            int diasRetraso = ReglasDeDevolucion.CalcularDiasRetraso(prestamo, fechaDevolucion);

            if (ReglasDeDevolucion.RequierePenalizacion(diasRetraso))
            {
                var penalizacion = new Penalizacion
                {
                    UsuarioId = prestamo.UsuarioId,
                    PrestamoId = prestamoId,
                    DiasRetraso = diasRetraso,
                    Estado = EstadoPenalizacion.Activa,
                    FechaPenalizacion = fechaDevolucion
                };
                _penalizacionRepo.Guardar(penalizacion);

                // Notificar penalización
                _notificacionServicio.Enviar(prestamo.UsuarioId, TipoNotificacion.PenalizacionAplicada,
                    $"Se aplicó una penalización por {diasRetraso} días de retraso.");

                // Auditoría penalización
                _auditoriaRepo.Registrar(new RegistroAuditoria
                {
                    TipoAccion = "AplicacionPenalizacion",
                    UsuarioSistema = prestamo.UsuarioId,
                    FechaHora = DateTime.Now,
                    Descripcion = $"Penalización aplicada — Usuario {prestamo.UsuarioId}, {diasRetraso} días de retraso",
                    TablaAfectada = "Penalizacion",
                    RegistroId = prestamoId
                });
            }

            prestamo.FechaDevolucion = fechaDevolucion;
            prestamo.Estado = EstadoPrestamo.Devuelto;
            _prestamoRepo.Actualizar(prestamo);

            var recurso = _recursoRepo.ObtenerPorId(prestamo.RecursoId);
            recurso.Estado = EstadoRecurso.Disponible;
            _recursoRepo.Actualizar(recurso);

            // Notificar devolución
            _notificacionServicio.Enviar(prestamo.UsuarioId, TipoNotificacion.DevolucionRegistrada,
                $"Tu devolución fue registrada correctamente.");

            // Auditoría devolución
            _auditoriaRepo.Registrar(new RegistroAuditoria
            {
                TipoAccion = "RegistroDevolucion",
                UsuarioSistema = prestamo.UsuarioId,
                FechaHora = DateTime.Now,
                Descripcion = $"Devolución registrada — Préstamo {prestamoId}",
                TablaAfectada = "Prestamo",
                RegistroId = prestamoId
            });
        }
    }
}