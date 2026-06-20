using Microsoft.EntityFrameworkCore;
using SIGEBI.Domain.Entities.Auditoria;
using SIGEBI.Domain.Entities.Biblioteca;
using SIGEBI.Domain.Entities.Notificacion;
using SIGEBI.Domain.Entities.Penalizacion;
using SIGEBI.Domain.Entities.Prestamo;
using SIGEBI.Domain.Entities.Usuario;

namespace SIGEBI.Persistence
{
    public class SigebiDbContext : DbContext
    {
        public SigebiDbContext(DbContextOptions<SigebiDbContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Recurso> Recursos { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Penalizacion> Penalizaciones { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }
        public DbSet<RegistroAuditoria> Auditoria { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}