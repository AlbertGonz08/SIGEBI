using SIGEBI.Domain.Entities.Penalizacion;
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
    public class PenalizacionRepository : BaseRepository<Penalizacion>, IPenalizacionRepository
    {
        public PenalizacionRepository(SigebiDbContext context) : base(context) { }

        public void Actualizar(Penalizacion penalizacion)
        {
            _context.Penalizaciones.Update(penalizacion);
            _context.SaveChanges();
        }

        public void Guardar(Penalizacion penalizacion)
        {
            _context.Penalizaciones.Add(penalizacion);
            _context.SaveChanges();
        }

        public IEnumerable<Penalizacion> ObtenerActivasPorUsuario(int usuarioId)
        {
            return _context.Penalizaciones
                .Where(p => p.UsuarioId == usuarioId && p.Estado == EstadoPenalizacion.Activa)
                .ToList();
        }

        public IEnumerable<Penalizacion> ObtenerHistorialPorUsuario(int usuarioId)
        {
            return _context.Penalizaciones
                .Where(p => p.UsuarioId == usuarioId)
                .OrderByDescending(p => p.FechaPenalizacion)
                .ToList();

        }

        public Penalizacion ObtenerPorId(int id)
        {
            return _context.Penalizaciones
                .FirstOrDefault(p => p.Id == id);
        }
    }
}
