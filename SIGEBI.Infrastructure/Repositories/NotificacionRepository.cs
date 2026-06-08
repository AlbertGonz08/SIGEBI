using SIGEBI.Domain.Entities.Notificacion;
using SIGEBI.Domain.Repository;
using SIGEBI.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Infrastructure.Repositories
{
    public class NotificacionRepository : BaseRepository<Notificacion>, INotificacionRepository
    {
        public NotificacionRepository(SigebiDbContext context) : base(context) { }

        public void Guardar(Notificacion notificacion)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Notificacion> ObtenerPorUsuario(int usuarioId)
        {
            throw new NotImplementedException();
        }
    }
}