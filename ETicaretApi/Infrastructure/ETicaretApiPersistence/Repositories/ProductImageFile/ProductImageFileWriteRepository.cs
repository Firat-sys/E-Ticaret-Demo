using ETicaretApiPersistence.Contexts;
using ETicaretApplication.Repositories.ProductImageFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApiPersistence.Repositories.ProductImageFile
{
    public class ProductImageFileWriteRepository : WriteRepository<ETicaretApi_Domain.Entitys.ProductImageFile>, IProductImageWriteRepository
    {
        public ProductImageFileWriteRepository(ETicaretApiDbContext context) : base(context)
        {
        }
    }
}
