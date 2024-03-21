using ETicaretApiPersistence.Contexts;
using ETicaretApplication.Repositories.ProductImageFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApiPersistence.Repositories.ProductImageFile
{
    public class ProductImageReadRepository : ReadRepository<ETicaretApi_Domain.Entitys.ProductImageFile>, IProductImageFileReadRepository
    {
        public ProductImageReadRepository(ETicaretApiDbContext context) : base(context)
        {
        }
    }
}
