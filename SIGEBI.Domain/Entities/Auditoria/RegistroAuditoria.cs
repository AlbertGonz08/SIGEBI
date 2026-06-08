using SIGEBI.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Domain.Entities.Auditoria
{
    public class RegistroAuditoria : AuditEntity
    {
        public int Id { get; set; }
        public string TipoAccion { get; set; }
        public int? UsuarioSistemaId { get; set; }
        public DateTime FechaHora { get; set; }
        public string Descripcion { get; set; }
        public string TablaAfectada { get; set; }
        public int? RegistroId { get; set; }
    }
}
