using System.ComponentModel.DataAnnotations;

namespace SIGEBI.Application.DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        [MaxLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El correo es requerido.")]
        [MaxLength(100, ErrorMessage = "El correo no puede tener más de 100 caracteres.")]
        [EmailAddress(ErrorMessage = "El correo no tiene un formato válido.")]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "La cédula es requerida.")]
        [MaxLength(13, ErrorMessage = "La cédula no puede tener más de 13 caracteres.")]
        public string? Cedula { get; set; }

        public string? Estado { get; set; }
        public string? TipoUsuario { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida.")]
        [MaxLength(255, ErrorMessage = "La contraseña no puede tener más de 255 caracteres.")]
        public string? Contrasena { get; set; }

        [Range(1, 5, ErrorMessage = "El tipo de usuario debe ser entre 1 y 5.")]
        public int TipoUsuarioId { get; set; }

        [MaxLength(100, ErrorMessage = "La carrera no puede tener más de 100 caracteres.")]
        public string? Carrera { get; set; }

        [MaxLength(100, ErrorMessage = "El departamento no puede tener más de 100 caracteres.")]
        public string? Departamento { get; set; }
    }
}