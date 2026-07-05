using SIGEBI.Domain.Entities.Biblioteca;
using SIGEBI.Domain.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Domain.Rules
{
    public static class ReglasDePrestamo
    {
        private const int DiasPrestamoEstudiante = 7;
        private const int DiasPrestamoDocente = 14;
        private const int LimitePrestamoEstudiante = 2;
        private const int LimitePrestamoDocente = 4;

        // Calcula qué día exacto debe devolver el recurso según el tipo de usuario
        public static DateTime CalcularFechaLimite(Usuario usuario)
        {
            // TipoUsuarioId 2 = Docente, cualquier otro = Estudiante
            int dias = usuario.TipoUsuarioId == 2 ? DiasPrestamoDocente : DiasPrestamoEstudiante;
            return DateTime.Now.AddDays(dias);
        }

        // Verifica si el recurso está disponible físicamente en la biblioteca
        public static bool RecursoPuedeSerPrestado(Recurso recurso)
        {
            return recurso.EstaDisponible();
        }

        // Verifica si el usuario ya tiene demasiados libros prestados
        public static bool UsuarioAlcanzoLimite(Usuario usuario, int prestamosActivos)
        {
            int limite = usuario.TipoUsuarioId == 2 ? LimitePrestamoDocente : LimitePrestamoEstudiante;
            return prestamosActivos >= limite;
        }
    }
}

