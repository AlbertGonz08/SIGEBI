using SIGEBI.Domain.Entities.Prestamo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Domain.Repository
{
    public interface IPrestamoRepository
    {
        Prestamo ObtenerPorId(int id);
        IEnumerable<Prestamo> ObtenerActivosPorUsuario(int usuarioId);
        IEnumerable<Prestamo> ObtenerHistorialPorUsuario(int usuarioId);
        IEnumerable<Prestamo> ObtenerVencidos();
        IEnumerable<Prestamo> ObtenerTodos();
        void Guardar(Prestamo prestamo);
        void Actualizar(Prestamo prestamo);
    }

}