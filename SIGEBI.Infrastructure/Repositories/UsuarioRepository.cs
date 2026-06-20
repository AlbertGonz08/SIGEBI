using SIGEBI.Domain.Entities.Usuario;
using SIGEBI.Domain.Repository;
using SIGEBI.Persistence;
using Microsoft.EntityFrameworkCore;

namespace SIGEBI.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SigebiDbContext context) : base(context) { }

        public void Guardar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Actualizar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        public Usuario ObtenerPorId(int id)
        {
            return _context.Usuarios
                .FirstOrDefault(u => u.Id == id);
        }

        public Usuario ObtenerPorCedula(string cedula)
        {
            return _context.Usuarios
                .FirstOrDefault(u => u.Cedula == cedula);
        }

        public IEnumerable<Usuario> Listar()
        {
            return _context.Usuarios
                .OrderBy(u => u.Nombre)
                .ToList();
        }
    }
}