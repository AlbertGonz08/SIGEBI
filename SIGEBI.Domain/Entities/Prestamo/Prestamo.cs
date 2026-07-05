using SIGEBI.Domain.Base;
using SIGEBI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Domain.Entities.Prestamo
{
    public class Prestamo
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int RecursoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaLimite { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public EstadoPrestamo Estado { get; set; }
        public int? CreadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? ModificadoPor { get; set; }

        public bool EstaVencido() => DateTime.Now > FechaLimite && Estado == EstadoPrestamo.Activo;
        public bool FueDevueltoATiempo() => FechaDevolucion.HasValue && FechaDevolucion.Value <= FechaLimite;
    }
}