using SIGEBI.Domain.Entities.Biblioteca;
using SIGEBI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Domain.Rules
{

    public static class ReglasDeInventario
    {
        // No tiene sentido registrar un recurso sin título, autor o ISBN
        public static bool RecursoPuedeSerRegistrado(Recurso recurso)
        {
            return !string.IsNullOrWhiteSpace(recurso.Titulo)
                && !string.IsNullOrWhiteSpace(recurso.Autor)
                && !string.IsNullOrWhiteSpace(recurso.ISBN);
        }

        // No se puede dar de baja un recurso que alguien tiene prestado
        public static bool RecursoPuedeDarseDeBaja(Recurso recurso)
        {
            return recurso.Estado != EstadoRecurso.Prestado;
        }

        // Solo los recursos dañados pueden reactivarse, no los dados de baja
        public static bool RecursoPuedeReactivarse(Recurso recurso)
        {
            return recurso.Estado == EstadoRecurso.FueraDeServicio;
        }

        // Verifica si hay ejemplares disponibles para prestar
        public static bool HayEjemplaresDisponibles(Recurso recurso)
        {
            return recurso.CantidadEjemplares > 0 && recurso.EstaDisponible();
        }
    }
}
