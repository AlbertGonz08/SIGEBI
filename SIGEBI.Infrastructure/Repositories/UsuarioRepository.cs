using SIGEBI.Domain.Entities.Usuario;
using SIGEBI.Domain.Repository;
using SIGEBI.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SigebiDbContext context) : base(context) { }

        public void Actualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Guardar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> Listar()
        {
            throw new NotImplementedException();
        }

        public Usuario ObtenerPorCedula(string cedula)
        {
            throw new NotImplementedException();
        }

        public Usuario ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
