using ECommerce.Persistance.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ECommerce.Persistance.Repositories.CustomerRepository;
using ECommerce.Application.Repositories.CustomerRepository;
using ECommerce.Application.Repositories.OrderRepository;
using ECommerce.Persistance.Repositories.OrderRepository;
using ECommerce.Application.Repositories.ProductRepository;
using ECommerce.Persistance.Repositories.ProductRepository;
using ECommerce.Application.Repositories.ProductImageFile;
using ECommerce.Application.Repositories.FileRepository;
using ECommerce.Persistance.Repositories.FileRepository;
using ECommerce.Persistance.Repositories.ProductImageRepository;
using ECommerce.Application.Repositories.InvoiceFile;
using ECommerce.Domain.Entities.Identity;
using ECommerce.Persistance.Repositories.InvoiceFileRepository;

namespace ECommerce.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            //burada hangi db yi kullanacaksak onunla ilgili kütüphaneyi yüklememiz gerekiyor. Postgre ise postgre , mssql ise mssql, mongo ise mongo gibi.
            services.AddDbContext<ECommerceAPIDbContext>(options => options.UseSqlServer(Configuration.ConnectionString), ServiceLifetime.Singleton);

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ECommerceAPIDbContext>(); 
            //Identity mekanizmasına dair tüm store işlerini buradan yürüt. Ve Asp.net.Identity nin kendine ait validationları vardır. Option ile kendimize göre onu configure ederiz.

            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IFileReadRepository, FileReadRepository>();
            services.AddScoped<IFileWriteRepository, FileWriteRepository>();
            services.AddScoped<IProductImageFileReadRepository, ProductImageReadRepository>();
            services.AddScoped<IProductImageFileWriteRepository, ProductImageWriteRepository>();
            services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
            services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();
        }
    }
}