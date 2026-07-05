using SIGEBI.Domain.Entities.Prestamo;
using SIGEBI.Domain.Enums;
using SIGEBI.Domain.Repository;
using SIGEBI.Domain.Rules;

namespace SIGEBI.Application.Services
{
    public class PrestamoServicio
    {
        private readonly IPrestamoRepository _prestamoRepo;
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IRecursoRepository _recursoRepo;
        private readonly IPenalizacionRepository _penalizacionRepo;

        public PrestamoServicio(IPrestamoRepository prestamoRepo, IUsuarioRepository usuarioRepo,
            IRecursoRepository recursoRepo, IPenalizacionRepository penalizacionRepo)
        {
            _prestamoRepo = prestamoRepo;
            _usuarioRepo = usuarioRepo;
            _recursoRepo = recursoRepo;
            _penalizacionRepo = penalizacionRepo;
        }

        // Validae todo antes de aprobar un préstamo y lo registra
        public void SolicitarPrestamo(int usuarioId, int recursoId)
        {
            var usuario = _usuarioRepo.ObtenerPorId(usuarioId);
            var penalizaciones = _penalizacionRepo.ObtenerActivasPorUsuario(usuarioId);
            var prestamosActivos = _prestamoRepo.ObtenerActivosPorUsuario(usuarioId);
            var recurso = _recursoRepo.ObtenerPorId(recursoId);


            if (!ReglasDeAcceso.PuedeRealizarPrestamo(usuario, penalizaciones))
                throw new Exception("El usuario no puede realizar préstamos.");

            if (ReglasDePrestamo.UsuarioAlcanzoLimite(usuario, prestamosActivos.Count()))
                throw new Exception("El usuario alcanzó su límite de préstamos.");

            if (!ReglasDePrestamo.RecursoPuedeSerPrestado(recurso))
                throw new Exception("El recurso no está disponible.");

            var prestamo = new Prestamo
            {
                UsuarioId = usuarioId,
                RecursoId = recursoId,
                FechaInicio = DateTime.Now,
                FechaLimite = ReglasDePrestamo.CalcularFechaLimite(usuario),
                Estado = EstadoPrestamo.Activo
            };

            _prestamoRepo.Guardar(prestamo);

            // Actualizar el recurso a Prestado
            recurso.Estado = EstadoRecurso.Prestado;
            _recursoRepo.Actualizar(recurso);
        }
    }
}