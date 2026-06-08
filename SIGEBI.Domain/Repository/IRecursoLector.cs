using SIGEBI.Domain.Entities.Biblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Domain.Repository
{
    public interface IRecursoLector
    {
        Recurso ObtenerPorId(int id);
        Recurso ObtenerPorISBN(string isbn);
        IEnumerable<Recurso> Listar();
        IEnumerable<Recurso> ListarDisponibles();
    }
}