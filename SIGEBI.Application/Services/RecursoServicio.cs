using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities.Biblioteca;
using SIGEBI.Domain.Enums;
using SIGEBI.Domain.Repository;
using SIGEBI.Domain.Rules;

namespace SIGEBI.Application.Services
{
    public class RecursoServicio : IRecursoServicio
    {
        private readonly IRecursoRepository _recursoRepo;

        public RecursoServicio(IRecursoRepository recursoRepo)
        {
            _recursoRepo = recursoRepo;
        }

        public void RegistrarRecurso(RecursoDto dto)
        {
            var recurso = new Recurso
            {
                Titulo = dto.Titulo,
                Autor = dto.Autor,
                ISBN = dto.ISBN,
                CategoriaId = dto.CategoriaId,
                CantidadEjemplares = dto.CantidadEjemplares,
                Estado = EstadoRecurso.Disponible,
                FechaIngreso = DateTime.Now
            };

            if (!ReglasDeInventario.RecursoPuedeSerRegistrado(recurso))
                throw new Exception("El recurso no tiene la información mínima requerida.");

            _recursoRepo.Guardar(recurso);
        }

        public IEnumerable<Recurso> ObtenerCatalogo() => _recursoRepo.Listar();
        public IEnumerable<Recurso> ObtenerDisponibles() => _recursoRepo.ListarDisponibles();
        public Recurso ObtenerPorId(int id) => _recursoRepo.ObtenerPorId(id);
    
    public void DarDeBaja(int id)
        {
            var recurso = _recursoRepo.ObtenerPorId(id);
            if (recurso == null)
                throw new Exception("Recurso no encontrado.");

            if (!ReglasDeInventario.RecursoPuedeDarseDeBaja(recurso))
                throw new Exception("No se puede dar de baja un recurso que tiene préstamos activos.");

            recurso.Estado = EstadoRecurso.FueraDeServicio;
            _recursoRepo.Actualizar(recurso);
        }
    }
}