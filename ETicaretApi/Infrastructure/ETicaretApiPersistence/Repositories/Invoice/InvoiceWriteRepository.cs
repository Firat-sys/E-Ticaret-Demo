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
    public class InvoiceWriteRepository : WriteRepository<InvoiceFile>, IInvoiceWriteRepository
    {
        public InvoiceWriteRepository(ETicaretApiDbContext context) : base(context)
        {
        }
    }
}
