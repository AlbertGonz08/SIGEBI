using SIGEBI.Domain.Entities.Penalizacion;
using SIGEBI.Domain.Entities.Prestamo;
using SIGEBI.Domain.Repository;

public class ReporteServicio
{
    private readonly IPrestamoRepository _prestamoRepo;
    private readonly IPenalizacionRepository _penalizacionRepo;

    public ReporteServicio(IPrestamoRepository prestamoRepo, IPenalizacionRepository penalizacionRepo)
    {
        _prestamoRepo = prestamoRepo;
        _penalizacionRepo = penalizacionRepo;
    }

    // Préstamos realizados en un rango de fechas
    public IEnumerable<Prestamo> ObtenerPrestamosPorRango(DateTime desde, DateTime hasta)
    {
        return _prestamoRepo.ObtenerHistorialPorUsuario(0)
            .Where(p => p.FechaInicio >= desde && p.FechaInicio <= hasta);
    }

    // Préstamos que están vencidos actualmente
    public IEnumerable<Prestamo> ObtenerVencidos()
    {
        return _prestamoRepo.ObtenerVencidos();
    }

    // Usuarios que tienen penalizaciones activas
    public IEnumerable<Penalizacion> ObtenerPenalizacionesActivas()
    {
        return _penalizacionRepo.ObtenerHistorialPorUsuario(0)
            .Where(p => p.EstaActiva());
    }
}