using SIGEBI.Domain.Entities.Auditoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Domain.Repository
{
    public interface IAuditoriaRepository
    {
        public void Registrar(RegistroAuditoria registro);
        IEnumerable<RegistroAuditoria> ObtenerPorRango(DateTime desde, DateTime hasta);
    }
}