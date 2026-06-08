using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGEBI.Persistence;
namespace SIGEBI.Infrastructure.Repositories
{
public abstract class BaseRepository<T> where T : class
    {
        protected readonly SigebiDbContext _context;

        public BaseRepository(SigebiDbContext context)
        {
            _context = context;
        }
    }
}
