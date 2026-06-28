using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.DTOs
{
    public class PenalizacionDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public int DiasRetraso { get; set; }
        public string Estado { get; set; }
        public DateTime FechaPenalizacion { get; set; }
    }
}