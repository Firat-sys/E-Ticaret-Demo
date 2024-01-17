using ETicaretApi_Domain.Entitys;
using ETicaretApiPersistence.Contexts;
using ETicaretApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApiPersistence.Repositories
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(ETicaretApiDbContext context) : base(context)
        {
        }
    }
}
