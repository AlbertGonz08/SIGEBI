using SIGEBI.Domain.Entities.Prestamo;
using SIGEBI.Domain.Repository;
using SIGEBI.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Infrastructure.Repositories
{
    public class PrestamoRepository : BaseRepository<Prestamo>, IPrestamoRepository
    {
        public PrestamoRepository(SigebiDbContext context) : base(context) { }

        public void Actualizar(Prestamo prestamo)
        {
            throw new NotImplementedException();
        }

        public void Guardar(Prestamo prestamo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Prestamo> ObtenerActivosPorUsuario(int usuarioId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Prestamo> ObtenerHistorialPorUsuario(int usuarioId)
        {
            throw new NotImplementedException();
        }

        public Prestamo ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Prestamo> ObtenerVencidos()
        {
            throw new NotImplementedException();
        }
    }
}