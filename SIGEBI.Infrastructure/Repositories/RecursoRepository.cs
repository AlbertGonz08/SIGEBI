using SIGEBI.Domain.Entities.Biblioteca;
using SIGEBI.Domain.Enums;
using SIGEBI.Domain.Repository;
using SIGEBI.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Infrastructure.Repositories
{
    public class RecursoRepository : BaseRepository<Recurso>, IRecursoRepository
    {
        public RecursoRepository(SigebiDbContext context) : base(context) { }
        public void Guardar(Recurso recurso)
        {
            _context.Recursos.Add(recurso);
            _context.SaveChanges();
        }

        public void Actualizar(Recurso recurso)
        {
            _context.Recursos.Update(recurso);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var recurso = _context.Recursos.Find(id);
            if (recurso != null)
            {
                _context.Recursos.Remove(recurso);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Recurso> Listar()
        {
            return _context.Recursos
                .OrderBy(r => r.Titulo)
                .ToList();
        }

        public IEnumerable<Recurso> ListarDisponibles()
        {
            return _context.Recursos
                .Where(r => r.Estado == EstadoRecurso.Disponible)
                .OrderBy(r => r.Titulo)
                .ToList();
        }

        public Recurso ObtenerPorId(int id)
        {
            return _context.Recursos
                .FirstOrDefault(r => r.Id == id);
        }

        public Recurso ObtenerPorISBN(string isbn)
        {
            return _context.Recursos
                .FirstOrDefault(r => r.ISBN == isbn);
        }
    }
}
