using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities.Auditoria;
using SIGEBI.Domain.Repository;

namespace SIGEBI.Application.Services
{
    public class AuditoriaServicio : IAuditoriaServicio
    {
        private readonly IAuditoriaRepository _auditoriaRepo;

        public AuditoriaServicio(IAuditoriaRepository auditoriaRepo)
        {
            _auditoriaRepo = auditoriaRepo;
        }

        public IEnumerable<RegistroAuditoria> ObtenerPorRango(DateTime desde, DateTime hasta)
        {
            return _auditoriaRepo.ObtenerPorRango(desde, hasta);
        }
    }
}