using ETicaretApiPersistence.Contexts;
using ETicaretApplication.Repositories.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApiPersistence.Repositories.File
{
    public class FileReadRepository : ReadRepository<ETicaretApi_Domain.Entitys.File>, IFileReadRepository
    {
        public FileReadRepository(ETicaretApiDbContext context) : base(context)
        {
        }
    }
}
