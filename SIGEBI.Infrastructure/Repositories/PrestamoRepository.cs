using SIGEBI.Domain.Entities.Prestamo;
using SIGEBI.Domain.Enums;
using SIGEBI.Domain.Repository;
using SIGEBI.Persistence;
using Microsoft.EntityFrameworkCore;

namespace SIGEBI.Infrastructure.Repositories
{
    public class PrestamoRepository : BaseRepository<Prestamo>, IPrestamoRepository
    {
        public PrestamoRepository(SigebiDbContext context) : base(context) { }

        public void Guardar(Prestamo prestamo)
        {
            _context.Prestamos.Add(prestamo);
            _context.SaveChanges();
        }

        public void Actualizar(Prestamo prestamo)
        {
            _context.Prestamos.Update(prestamo);
            _context.SaveChanges();
        }

        public Prestamo ObtenerPorId(int id)
        {
            return _context.Prestamos
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Prestamo> ObtenerActivosPorUsuario(int usuarioId)
        {
            return _context.Prestamos
                .Where(p => p.UsuarioId == usuarioId
                    && p.Estado == EstadoPrestamo.Activo)
                .ToList();
        }

        public IEnumerable<Prestamo> ObtenerHistorialPorUsuario(int usuarioId)
        {
            return _context.Prestamos
                .Where(p => p.UsuarioId == usuarioId)
                .OrderByDescending(p => p.FechaInicio)
                .ToList();
        }

        public IEnumerable<Prestamo> ObtenerVencidos()
        {
            return _context.Prestamos
                .Where(p => p.Estado == EstadoPrestamo.Activo
                    && p.FechaLimite < DateTime.Now)
                .ToList();
        }
        public IEnumerable<Prestamo> ObtenerTodos()
        {
            return _context.Prestamos
                .OrderByDescending(p => p.FechaInicio)
                .ToList();
        }
    }
}