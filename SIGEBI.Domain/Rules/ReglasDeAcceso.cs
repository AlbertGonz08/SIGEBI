using SIGEBI.Domain.Entities.Penalizacion;
using SIGEBI.Domain.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Domain.Rules
{
    public static class ReglasDeAcceso
    {
        //evalúo si un usuario tiene permiso para llevarse un recurso (libro).
        public static bool PuedeRealizarPrestamo(Usuario usuario, IEnumerable<Penalizacion> penalizaciones)
        {
            // verifico si el usuario está activo (por ejemplo, si su cuenta no está suspendida o dada de baja).
            if (!usuario.EstaActivo()) return false;
            // verifico si el usuario es elegible (quizás no pagó su membresía o le falta un documento).
            if (!usuario.EsElegible()) return false;

            // si tiene alguna penalización activa, no puede pedir prestado
            bool tienePenalizacionActiva = penalizaciones.Any(p => p.EstaActiva());
            if (tienePenalizacionActiva) return false;
            // si el usuario pasó todas las validaciones, está limpio y puede realizar el prestamo.
            return true;
        }
    }
}