using SIGEBI.Domain.Entities.Biblioteca;

namespace SIGEBI.Domain.Repository
{
    public interface IRecursoEscritor
    {
        void Guardar(Recurso recurso);
        void Actualizar(Recurso recurso);
        void Eliminar(int id);
    }
}