using ECommerce.Application.Abstractions;
using ECommerce.Application.Abstractions.Services;
using ECommerce.Application.Abstractions.Services.Authentications;
using ECommerce.Persistance.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ECommerce.Persistance.Repositories.CustomerRepository;
using ECommerce.Application.Repositories.CustomerRepository;
using ECommerce.Application.Repositories.EndpointRepository;
using ECommerce.Application.Repositories.OrderRepository;
using ECommerce.Persistance.Repositories.OrderRepository;
using ECommerce.Application.Repositories.ProductRepository;
using ECommerce.Persistance.Repositories.ProductRepository;
using ECommerce.Application.Repositories.ProductImageFile;
using ECommerce.Application.Repositories.FileRepository;
using ECommerce.Persistance.Repositories.FileRepository;
using ECommerce.Persistance.Repositories.ProductImageRepository;
using ECommerce.Application.Repositories.InvoiceFile;
using ECommerce.Application.Repositories.MenuRepository;
using ECommerce.Domain.Entities.Identity;
using ECommerce.Persistance.Repositories.EndpointRepository;
using ECommerce.Persistance.Repositories.InvoiceFileRepository;
using ECommerce.Persistance.Repositories.MenuRepository;
using ECommerce.Persistance.Services;
using ECommerce.Application.Repositories.BasketItemRepository;
using ECommerce.Application.Repositories.BasketRepository;
using ECommerce.Persistance.Repositories.BasketItemRepository;
using ECommerce.Persistance.Repositories.BasketRepository;
using ECommerce.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using ECommerce.Application.Repositories.CompleteOrderRepository;
using ECommerce.Persistance.Repositories;

namespace ECommerce.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            //burada hangi db yi kullanacaksak onunla ilgili kütüphaneyi yüklememiz gerekiyor. Postgre ise postgre , mssql ise mssql, mongo ise mongo gibi.
            services.AddDbContext<ECommerceAPIDbContext>(options => 
            options.UseNpgsql(Configuration.ConnectionString), ServiceLifetime.Singleton);

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ECommerceAPIDbContext>()
             .AddDefaultTokenProviders(); //resetpasswordtoken vb metotları kullanmak için bu gerekmektedir.
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
            services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
            services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();
            services.AddScoped<IBasketReadRepository, BasketReadRepository>();
            services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();
            services.AddScoped<ICompletedOrderReadRepository, CompletedOrderReadRepository>();
            services.AddScoped<ICompletedOrderWriteRepository, CompletedOrderWriteRepository>();
            services.AddScoped<IEndpointReadRepository, EndpointReadRepository>();
            services.AddScoped<IEndpointWriteRepository, EndpointWriteRepository>();
            services.AddScoped<IMenuReadRepository, MenuReadRepository>();
            services.AddScoped<IMenuWriteRepository, MenuWriteRepository>();
            
            
            
            
            
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IExternalAuthentication, AuthService>();
            services.AddScoped<IInternalAuthentication, AuthService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IOrderService, OrderService>();
            // services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAuthorizationEndpointService, AuthorizationEndpointService>();
        }
    }
}