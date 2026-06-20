using SIGEBI.Domain.Entities.Prestamo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Domain.Rules
{
    public static class ReglasDeDevolucion
    {
        // Método que calcula cuántos días de retraso tiene una entrega.
        public static int CalcularDiasRetraso(Prestamo prestamo, DateTime fechaDevolucion)
        {
            if (fechaDevolucion <= prestamo.FechaLimite) return 0;

            return (int)(fechaDevolucion - prestamo.FechaLimite).TotalDays;
        }

        // método que decide si un usuario merece una sanción basándose en sus días de retraso.
        public static bool RequierePenalizacion(int diasRetraso)
        {
            // si los días de retraso son mayores a cero devuelve 'true' (Sí requiere penalización) 
            // Si los días de retraso son 0, devuelve 'false' (No requiere penalización).
            return diasRetraso > 0;
        }
    }
}