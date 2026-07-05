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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Estudiante>();
            modelBuilder.Ignore<Docente>();

            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Recurso>().ToTable("Recurso");
            modelBuilder.Entity<Prestamo>().ToTable("Prestamo");
            modelBuilder.Entity<Penalizacion>().ToTable("Penalizacion");
            modelBuilder.Entity<Notificacion>().ToTable("Notificacion");
            modelBuilder.Entity<RegistroAuditoria>().ToTable("Auditoria");
            modelBuilder.Entity<Categoria>().ToTable("Categoria");

            // Enums guardados como string en la BD
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Estado)
                .HasConversion<string>();

            modelBuilder.Entity<Recurso>()
                .Property(r => r.Estado)
                .HasConversion<string>();

            modelBuilder.Entity<Prestamo>()
                .Property(p => p.Estado)
                .HasConversion<string>();

            modelBuilder.Entity<Penalizacion>()
                .Property(p => p.Estado)
                .HasConversion<string>();

            modelBuilder.Entity<Notificacion>()
                .Property(n => n.Tipo)
                .HasConversion<string>();
        }
    }
    }
