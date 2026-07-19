using SIGEBI.Application.DTOs;
using SIGEBI.Domain.Entities.Biblioteca;

namespace SIGEBI.Application.Interfaces
{
    public interface IRecursoServicio
    {
        void RegistrarRecurso(RecursoDto dto);
        IEnumerable<Recurso> ObtenerCatalogo();
        IEnumerable<Recurso> ObtenerDisponibles();
        Recurso ObtenerPorId(int id);
        void DarDeBaja(int id);
    }
}