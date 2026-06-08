using SIGEBI.Domain.Entities.Penalizacion;
using SIGEBI.Domain.Repository;
using SIGEBI.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Infrastructure.Repositories
{
    public class PenalizacionRepository : BaseRepository<Penalizacion>, IPenalizacionRepository
    {
        public PenalizacionRepository(SigebiDbContext context) : base(context) { }

        public void Actualizar(Penalizacion penalizacion)
        {
            throw new NotImplementedException();
        }

        public void Guardar(Penalizacion penalizacion)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Penalizacion> ObtenerActivasPorUsuario(int usuarioId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Penalizacion> ObtenerHistorialPorUsuario(int usuarioId)
        {
            throw new NotImplementedException();
        }

        public Penalizacion ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
