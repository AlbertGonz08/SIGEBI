using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Domain.Entities.Usuario
{
    public class Docente : Usuario
    {
       
        public override bool EsElegible() => EstaActivo();
    }
}