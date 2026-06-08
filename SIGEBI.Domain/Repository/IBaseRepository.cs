using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Domain.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        T ObtenerPorId(int id);
        IEnumerable<T> Listar();
        void Guardar(T entidad);
        void Actualizar(T entidad);
        void Eliminar(int id);
    }
}