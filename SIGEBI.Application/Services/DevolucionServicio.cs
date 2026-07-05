using SIGEBI.Domain.Entities.Penalizacion;
using SIGEBI.Domain.Enums;
using SIGEBI.Domain.Repository;
using SIGEBI.Domain.Rules;
namespace SIGEBI.Application.Services
{
    public class DevolucionServicio
    {
        private readonly IPrestamoRepository _prestamoRepo;
        private readonly IRecursoRepository _recursoRepo;
        private readonly IPenalizacionRepository _penalizacionRepo;

        public DevolucionServicio(IPrestamoRepository prestamoRepo, IRecursoRepository recursoRepo,
            IPenalizacionRepository penalizacionRepo)
        {
            _prestamoRepo = prestamoRepo;
            _recursoRepo = recursoRepo;
            _penalizacionRepo = penalizacionRepo;
        }

        public void RegistrarDevolucion(int prestamoId)
        {
            var prestamo = _prestamoRepo.ObtenerPorId(prestamoId);
            var fechaDevolucion = DateTime.Now;

            // Calcular si hubo retraso
            int diasRetraso = ReglasDeDevolucion.CalcularDiasRetraso(prestamo, fechaDevolucion);

            // Si hubo retraso, penalizar al usuario
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
            }

            // Cerrar el préstamo y liberar el recurso
            prestamo.FechaDevolucion = fechaDevolucion;
            prestamo.Estado = EstadoPrestamo.Devuelto;
            _prestamoRepo.Actualizar(prestamo);

            var recurso = _recursoRepo.ObtenerPorId(prestamo.RecursoId);
            recurso.Estado = EstadoRecurso.Disponible;
            _recursoRepo.Actualizar(recurso);
        }
    }
}