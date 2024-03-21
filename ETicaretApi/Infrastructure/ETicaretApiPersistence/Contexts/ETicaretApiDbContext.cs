using ETicaretApi_Domain.Entitys;
using ETicaretApi_Domain.Entitys.Commen;
using ETicaretApi_Domain.Entitys.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApiPersistence.Contexts
{
    public class ETicaretApiDbContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public ETicaretApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ETicaretApi_Domain.Entitys.File> Files { get; set; }
        public DbSet<ProductImageFile> ProductImages { get; set; }
        public DbSet<InvoiceFile> InvoiceFiles { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntitys>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreateDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdateDate = DateTime.UtcNow,
                    _=>DateTime.UtcNow

                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
