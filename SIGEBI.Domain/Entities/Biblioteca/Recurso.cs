using SIGEBI.Domain.Base;
using SIGEBI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Domain.Entities.Biblioteca
{
    public class Recurso : AuditEntity
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int CategoriaId { get; set; }
        public int CantidadEjemplares { get; set; }
        public EstadoRecurso Estado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool EstaDisponible() => Estado == EstadoRecurso.Disponible;
    }
}
