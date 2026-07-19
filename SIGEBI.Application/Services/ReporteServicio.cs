using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities.Penalizacion;
using SIGEBI.Domain.Entities.Prestamo;
using SIGEBI.Domain.Enums;
using SIGEBI.Domain.Repository;

namespace SIGEBI.Application.Services
{
    public class ReporteServicio : IReporteServicio
    {
        private readonly IPrestamoRepository _prestamoRepo;
        private readonly IPenalizacionRepository _penalizacionRepo;

        public ReporteServicio(IPrestamoRepository prestamoRepo, IPenalizacionRepository penalizacionRepo)
        {
            _prestamoRepo = prestamoRepo;
            _penalizacionRepo = penalizacionRepo;
        }

        // Préstamos en un rango de fechas
        public IEnumerable<Prestamo> ObtenerPrestamosPorRango(DateTime desde, DateTime hasta)
        {
            return _prestamoRepo.ObtenerTodos()
                .Where(p => p.FechaInicio >= desde && p.FechaInicio <= hasta);
        }

        // Préstamos vencidos actualmente
        public IEnumerable<Prestamo> ObtenerVencidos()
        {
            return _prestamoRepo.ObtenerVencidos();
        }

        // Penalizaciones activas
        public IEnumerable<Penalizacion> ObtenerPenalizacionesActivas()
        {
            return _penalizacionRepo.ObtenerTodos()
                .Where(p => p.Estado == EstadoPenalizacion.Activa);
        }
    }
}