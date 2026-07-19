using SIGEBI.Domain.Entities.Penalizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Domain.Repository
{
    public interface IPenalizacionRepository
    {
        Penalizacion ObtenerPorId(int id);
        IEnumerable<Penalizacion> ObtenerActivasPorUsuario(int usuarioId);
        IEnumerable<Penalizacion> ObtenerHistorialPorUsuario(int usuarioId);
        IEnumerable<Penalizacion> ObtenerTodos();
        void Guardar(Penalizacion penalizacion);
        void Actualizar(Penalizacion penalizacion);
    }
}