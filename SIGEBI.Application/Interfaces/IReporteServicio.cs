using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SIGEBI.Domain.Entities.Penalizacion;
using SIGEBI.Domain.Entities.Prestamo;

namespace SIGEBI.Application.Interfaces
{
    public interface IReporteServicio
    {
        IEnumerable<Prestamo> ObtenerPrestamosPorRango(DateTime desde, DateTime hasta);
        IEnumerable<Prestamo> ObtenerVencidos();
        IEnumerable<Penalizacion> ObtenerPenalizacionesActivas();
    }
}