using ETicaretApi_Domain.Entitys;
using ETicaretApi_Domain.Entitys.Identity;
using ETicaretApiPersistence.Contexts;
using ETicaretApiPersistence.Repositories;
using ETicaretApiPersistence.Repositories.File;
using ETicaretApiPersistence.Repositories.Invoice;
using ETicaretApiPersistence.Repositories.ProductImageFile;
using ETicaretApplication.Repositories;
using ETicaretApplication.Repositories.File;
using ETicaretApplication.Repositories.Invoice;
using ETicaretApplication.Repositories.ProductImageFile;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApiPersistence
{
    public static class ServiceRegistraction
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ETicaretApiDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            //services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ETicaretApiDbContext>();
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ETicaretApiDbContext>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriterRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IFileWriteRepository, FileWriteRepository>();
            services.AddScoped<IFileReadRepository, FileReadRepository>();
            services.AddScoped<IInvoiceWriteRepository, InvoiceWriteRepository>();
            services.AddScoped<IInvoiceReadRepository, InvoiceReadRepository>();
            services.AddScoped<IProductImageWriteRepository, ProductImageFileWriteRepository>();
            services.AddScoped<IProductImageFileReadRepository, ProductImageReadRepository>();
        }
    }
}
