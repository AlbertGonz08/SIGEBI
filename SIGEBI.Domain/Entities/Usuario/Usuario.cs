using SIGEBI.Domain.Base;
using SIGEBI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Domain.Entities.Usuario
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Cedula { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        public int TipoUsuarioId { get; set; }
        public EstadoUsuario Estado { get; set; }
        public string? Carrera { get; set; }        // Solo Estudiante
        public string? Departamento { get; set; }   // Solo Docente
        public DateTime FechaRegistro { get; set; }
        public int? CreadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? ModificadoPor { get; set; }

        public virtual bool EsElegible() => EstaActivo();
        public bool EstaActivo() => Estado == EstadoUsuario.Activo;
    }
}
