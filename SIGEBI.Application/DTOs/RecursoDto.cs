using System.ComponentModel.DataAnnotations;

namespace SIGEBI.Application.DTOs
{
    public class RecursoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es requerido.")]
        [MaxLength(200, ErrorMessage = "El título no puede tener más de 200 caracteres.")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "El autor es requerido.")]
        [MaxLength(150, ErrorMessage = "El autor no puede tener más de 150 caracteres.")]
        public string? Autor { get; set; }

        [MaxLength(20, ErrorMessage = "El ISBN no puede tener más de 20 caracteres.")]
        public string? ISBN { get; set; }

        [Range(1, 9999, ErrorMessage = "La cantidad de ejemplares debe ser entre 1 y 9999.")]
        public int CantidadEjemplares { get; set; }

        public string? Estado { get; set; }
    }
}