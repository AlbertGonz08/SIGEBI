using SIGEBI.Application.DTOs;
using SIGEBI.Domain.Entities.Prestamo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.Mappers
{
    public static class PrestamoMapper
    {
        public static PrestamoDto ToDto(Prestamo prestamo)
        {
            return new PrestamoDto
            {
                Id = prestamo.Id,
                UsuarioId = prestamo.UsuarioId,
                RecursoId = prestamo.RecursoId,
                FechaInicio = prestamo.FechaInicio,
                FechaLimite = prestamo.FechaLimite,
                Estado = prestamo.Estado.ToString()
            };
        }
    }
}