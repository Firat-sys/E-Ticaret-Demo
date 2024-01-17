using ETicaretApi_Domain.Entitys.Commen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApplication.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntitys
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        bool Update(T model);
      Task<  bool> Remove(string id);
         bool Remove(T id);
        bool RemoveRange(List<T> datas);
        Task<int> SaveAsync();
    }
}
