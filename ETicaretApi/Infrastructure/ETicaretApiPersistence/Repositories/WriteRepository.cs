using ETicaretApi_Domain.Entitys.Commen;
using ETicaretApiPersistence.Contexts;
using ETicaretApplication.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApiPersistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntitys
    {
        readonly private ETicaretApiDbContext _context;

        public WriteRepository(ETicaretApiDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public async Task<bool> Remove(string id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            return Remove(model);
        }

        public bool Remove(T id)
        {
            EntityEntry entityEntry = Table.Remove(id);
            return entityEntry.State == EntityState.Deleted;

        }

        public bool RemoveRange(List<T> datas)
        {
         Table.RemoveRange(datas);
            return true;
        }

        public async Task<int> SaveAsync()
       => await _context.SaveChangesAsync();
        public bool Update(T model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
