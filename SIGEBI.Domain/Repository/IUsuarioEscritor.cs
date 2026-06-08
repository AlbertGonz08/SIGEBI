using SIGEBI.Domain.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Domain.Repository
{
    public interface IUsuarioEscritor
    {
        void Guardar(Usuario usuario);
        void Actualizar(Usuario usuario);
    }
}