using SIGEBI.Domain.Entities.Biblioteca;
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

        public IEnumerable<Recurso> Listar()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Recurso> ListarDisponibles()
        {
            throw new NotImplementedException();
        }

        public Recurso ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Recurso ObtenerPorISBN(string isbn)
        {
            throw new NotImplementedException();
        }
    }
}
