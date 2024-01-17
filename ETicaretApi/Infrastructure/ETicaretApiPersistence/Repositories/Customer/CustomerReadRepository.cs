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
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(ETicaretApiDbContext context) : base(context)
        {
        }
    }
}
