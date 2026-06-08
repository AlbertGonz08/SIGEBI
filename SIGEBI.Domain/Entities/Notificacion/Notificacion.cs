using SIGEBI.Domain.Base;
using SIGEBI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Domain.Entities.Notificacion
{
    public class Notificacion : AuditEntity
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public TipoNotificacion Tipo {  get; set; }

        public string Mensaje { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public bool FueEnviada { get; set; }
        public void MarcarComoEnviada() => FueEnviada = true;
    } 
}
