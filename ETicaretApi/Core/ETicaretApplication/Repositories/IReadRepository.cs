using ETicaretApi_Domain.Entitys.Commen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApplication.Repositories
{
    public interface IReadRepository<T>:IRepository<T> where T: BaseEntitys
    {
        IQueryable<T> GetAll( bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T,bool>> method, bool tracking = true);
       Task< T> GetSigleAsync(Expression<Func<T,bool>> method, bool tracking = true);
        Task<T> GetByIdAsync(string id  , bool tracking = true);
     
    }
}
 