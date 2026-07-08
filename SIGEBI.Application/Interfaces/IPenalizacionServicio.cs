using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SIGEBI.Domain.Entities.Penalizacion;

namespace SIGEBI.Application.Interfaces
{
    public interface IPenalizacionServicio
    {
        void ResolverPenalizacion(int penalizacionId);
        IEnumerable<Penalizacion> ObtenerActivasPorUsuario(int usuarioId);
    }
}