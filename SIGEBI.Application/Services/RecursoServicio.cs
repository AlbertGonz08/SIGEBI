using SIGEBI.Domain.Entities.Biblioteca;
using SIGEBI.Domain.Repository;
using SIGEBI.Domain.Rules;
namespace SIGEBI.Application.Services
{
    public class RecursoServicio
    {
        private readonly IRecursoRepository _recursoRepo;

        public RecursoServicio(IRecursoRepository recursoRepo)
        {
            _recursoRepo = recursoRepo;
        }

        public void RegistrarRecurso(Recurso recurso)
        {
            // Validar que tenga la información mínima antes de guardar
            if (!ReglasDeInventario.RecursoPuedeSerRegistrado(recurso))
                throw new Exception("El recurso no tiene la información mínima requerida.");

            _recursoRepo.Guardar(recurso);
        }

        public IEnumerable<Recurso> ObtenerCatalogo() => _recursoRepo.Listar();

        public IEnumerable<Recurso> ObtenerDisponibles() => _recursoRepo.ListarDisponibles();

        public Recurso ObtenerPorId(int id) => _recursoRepo.ObtenerPorId(id);
    }
}