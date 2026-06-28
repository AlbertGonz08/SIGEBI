using SIGEBI.Domain.Entities.Penalizacion;
using SIGEBI.Domain.Enums;
using SIGEBI.Domain.Repository;

public class PenalizacionServicio
{
    private readonly IPenalizacionRepository _penalizacionRepo;
    private readonly IUsuarioRepository _usuarioRepo;

    public PenalizacionServicio(IPenalizacionRepository penalizacionRepo, IUsuarioRepository usuarioRepo)
    {
        _penalizacionRepo = penalizacionRepo;
        _usuarioRepo = usuarioRepo;
    }

    // El bibliotecario resuelve una penalización manualmente
    public void ResolverPenalizacion(int penalizacionId)
    {
        var penalizacion = _penalizacionRepo.ObtenerPorId(penalizacionId);
        penalizacion.Estado = EstadoPenalizacion.Resuelta;
        penalizacion.FechaResolucion = DateTime.Now;
        _penalizacionRepo.Actualizar(penalizacion);
    }

    public IEnumerable<Penalizacion> ObtenerActivasPorUsuario(int usuarioId)
    {
        return _penalizacionRepo.ObtenerActivasPorUsuario(usuarioId);
    }
}
