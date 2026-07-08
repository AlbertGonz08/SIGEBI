using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.Interfaces
{
    public interface IPrestamoServicio
    {
        void SolicitarPrestamo(int usuarioId, int recursoId);
    }
}