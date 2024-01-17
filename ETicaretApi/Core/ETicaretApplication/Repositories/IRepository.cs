using ETicaretApi_Domain.Entitys.Commen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApplication.Repositories
{
    public interface IRepository<T> where T : BaseEntitys
    {
        DbSet<T> Table {  get; }
    }
}
