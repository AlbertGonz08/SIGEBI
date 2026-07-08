using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SIGEBI.Domain.Entities.Notificacion;
using SIGEBI.Domain.Enums;

namespace SIGEBI.Application.Interfaces
{
    public interface INotificacionServicio
    {
        void Enviar(int usuarioId, TipoNotificacion tipo, string mensaje);
        IEnumerable<Notificacion> ObtenerPorUsuario(int usuarioId);
    }
}