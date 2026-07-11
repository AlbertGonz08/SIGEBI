namespace SIGEBI.Application.DTOs
{
    public class UsuarioDto
    {
        // Para GET — salida
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Cedula { get; set; }
        public string? Estado { get; set; }
        public string? TipoUsuario { get; set; }

        // Para POST — entrada (no se devuelven en GET)
        public string? Contrasena { get; set; }
        public int TipoUsuarioId { get; set; }
        public string? Carrera { get; set; }
        public string? Departamento { get; set; }
    }
}