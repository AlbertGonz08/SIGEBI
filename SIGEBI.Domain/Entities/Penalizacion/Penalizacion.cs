using SIGEBI.Domain.Base;
using SIGEBI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Domain.Entities.Penalizacion
{
    public class Penalizacion : AuditEntity
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int PrestamoId { get; set; }
        public int DiasRetraso { get; set; }
        public EstadoPenalizacion Estado { get; set; }
        public DateTime FechaPenalizacion { get; set; }
        public DateTime? FechaResolucion { get; set; }
        public string Observaciones { get; set; }
        public bool EstaActiva() => Estado == EstadoPenalizacion.Activa;
    }
}
