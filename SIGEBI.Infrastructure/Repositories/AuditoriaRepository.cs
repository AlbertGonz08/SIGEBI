using SIGEBI.Domain.Entities.Auditoria;
using SIGEBI.Domain.Repository;
using SIGEBI.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Infrastructure.Repositories
{
    public class AuditoriaRepository : BaseRepository<RegistroAuditoria>, IAuditoriaRepository
    {
        public AuditoriaRepository(SigebiDbContext context) : base(context) { }

        public IEnumerable<RegistroAuditoria> ObtenerPorRango(DateTime desde, DateTime hasta)
        {
            throw new NotImplementedException();
        }

        public void Registrar(RegistroAuditoria registro)
        {
            throw new NotImplementedException();
        }
    }
}
