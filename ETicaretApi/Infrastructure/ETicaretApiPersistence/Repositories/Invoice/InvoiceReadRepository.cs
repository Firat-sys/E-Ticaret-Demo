using ETicaretApi_Domain.Entitys;
using ETicaretApiPersistence.Contexts;
using ETicaretApplication.Repositories.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApiPersistence.Repositories.Invoice
{
    public class InvoiceReadRepository : ReadRepository<InvoiceFile>, IInvoiceReadRepository
    {
        public InvoiceReadRepository(ETicaretApiDbContext context) : base(context)
        {
        }
    }
}
