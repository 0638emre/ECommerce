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

namespace ECommerce.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            //burada hangi db yi kullanacaksak onunla ilgili kütüphaneyi yüklememiz gerekiyor. Postgre ise postgre , mssql ise mssql, mongo ise mongo gibi.
            services.AddDbContext<ECommerceAPIDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ECommerceDB")), ServiceLifetime.Singleton);
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        }
    }
}