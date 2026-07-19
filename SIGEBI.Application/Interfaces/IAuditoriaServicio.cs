using SIGEBI.Domain.Entities.Auditoria;

namespace SIGEBI.Application.Interfaces
{
    public interface IAuditoriaServicio
    {
        IEnumerable<RegistroAuditoria> ObtenerPorRango(DateTime desde, DateTime hasta);
    }
}