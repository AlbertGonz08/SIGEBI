using SIGEBI.Domain.Entities.Notificacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SIGEBI.Domain.Repository
{
    public interface INotificacionRepository
    {
        void Guardar(Notificacion notificacion);
        IEnumerable<Notificacion> ObtenerPorUsuario(int usuarioId);
    }
}