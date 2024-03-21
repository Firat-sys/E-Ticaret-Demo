using ETicaretApiPersistence.Contexts;
using ETicaretApplication.Repositories.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApiPersistence.Repositories.File
{
    public class FileWriteRepository : WriteRepository<ETicaretApi_Domain.Entitys.File>, IFileWriteRepository
    {
        public FileWriteRepository(ETicaretApiDbContext context) : base(context)
        {
        }
    }
}
