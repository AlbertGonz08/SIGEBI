using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SIGEBI.Domain.Entities.Biblioteca;

namespace SIGEBI.Application.Interfaces
{
    public interface IRecursoServicio
    {
        void RegistrarRecurso(Recurso recurso);
        IEnumerable<Recurso> ObtenerCatalogo();
        IEnumerable<Recurso> ObtenerDisponibles();
        Recurso ObtenerPorId(int id);
    }
}