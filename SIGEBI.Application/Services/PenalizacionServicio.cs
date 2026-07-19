using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities.Auditoria;
using SIGEBI.Domain.Entities.Penalizacion;
using SIGEBI.Domain.Enums;
using SIGEBI.Domain.Repository;

namespace SIGEBI.Application.Services
{
    public class PenalizacionServicio : IPenalizacionServicio
    {
        private readonly IPenalizacionRepository _penalizacionRepo;
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IAuditoriaRepository _auditoriaRepo;

        public PenalizacionServicio(IPenalizacionRepository penalizacionRepo,
            IUsuarioRepository usuarioRepo, IAuditoriaRepository auditoriaRepo)
        {
            _penalizacionRepo = penalizacionRepo;
            _usuarioRepo = usuarioRepo;
            _auditoriaRepo = auditoriaRepo;
        }

        public void ResolverPenalizacion(int penalizacionId)
        {
            var penalizacion = _penalizacionRepo.ObtenerPorId(penalizacionId);
            if (penalizacion == null)
                throw new Exception("Penalización no encontrada.");

            penalizacion.Estado = EstadoPenalizacion.Resuelta;
            penalizacion.FechaResolucion = DateTime.Now;
            _penalizacionRepo.Actualizar(penalizacion);

            // Auditoría penalización resuelta
            _auditoriaRepo.Registrar(new RegistroAuditoria
            {
                TipoAccion = "ResolucionPenalizacion",
                UsuarioSistema = penalizacion.UsuarioId,
                FechaHora = DateTime.Now,
                Descripcion = $"Penalización resuelta — ID {penalizacionId}",
                TablaAfectada = "Penalizacion",
                RegistroId = penalizacionId
            });
        }

        public IEnumerable<Penalizacion> ObtenerActivasPorUsuario(int usuarioId)
        {
            return _penalizacionRepo.ObtenerActivasPorUsuario(usuarioId);
        }
    }
}