using SIGEBI.Domain.Base;
using SIGEBI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Domain.Entities.Usuario
{
    public abstract class Usuario : AuditEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        public EstadoUsuario Estado {  get; set; }

        public abstract bool EsElegible();
        public bool EstaActivo() => Estado == EstadoUsuario.Activo;
    }
}
