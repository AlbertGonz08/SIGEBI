using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Domain.Base
{
    public abstract class AuditEntity
    {
        public DateTime FechaCreacion { get; set; }
        public int? CreadoPor {  get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? ModificadoPor {  get; set; }
    }
}
