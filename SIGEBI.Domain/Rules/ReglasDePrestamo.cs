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

        // método que calcula qué día exacto debe devolver el recurso el usuario.
        public static DateTime CalcularFechaLimite(Usuario usuario)
        {
            //evalúo qué tipo de usuario es usando el operador 'is' (ya que los docentes se le asigna 14 días y a los estudiantes 7)
            int dias = usuario is Docente ? DiasPrestamoDocente : DiasPrestamoEstudiante;
            // toma la fecha y hora actual (DateTime.Now), le suma los días calculados y devuelve la fecha limite de entrega
            return DateTime.Now.AddDays(dias);
        }

        // método para revisar si está disponible el libro físico en la biblioteca
        public static bool RecursoPuedeSerPrestado(Recurso recurso)
        {
            return recurso.EstaDisponible();
        }

        // método que verifica si el usuario ya tiene demasiados libros prestados.
        public static bool UsuarioAlcanzoLimite(Usuario usuario, int prestamosActivos)
        {
            int limite = usuario is Docente ? LimitePrestamoDocente : LimitePrestamoEstudiante;
            return prestamosActivos >= limite;
        }
    }
}

