using SIGEBI.Application.DTOs;
using SIGEBI.Domain.Entities.Penalizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.Mappers
{
    public static class PenalizacionMapper
    {
        public static PenalizacionDto ToDto(Penalizacion penalizacion)
        {
            return new PenalizacionDto
            {
                Id = penalizacion.Id,
                UsuarioId = penalizacion.UsuarioId,
                DiasRetraso = penalizacion.DiasRetraso,
                Estado = penalizacion.Estado.ToString(),
                FechaPenalizacion = penalizacion.FechaPenalizacion
            };
        }
    }
}