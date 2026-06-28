using SIGEBI.Application.DTOs;
using SIGEBI.Domain.Entities.Biblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.Mappers
{
    public static class RecursoMapper
    {
        public static RecursoDto ToDto(Recurso recurso)
        {
            return new RecursoDto
            {
                Id = recurso.Id,
                Titulo = recurso.Titulo,
                Autor = recurso.Autor,
                ISBN = recurso.ISBN,
                CantidadEjemplares = recurso.CantidadEjemplares,
                Estado = recurso.Estado.ToString()
            };
        }
    }
}