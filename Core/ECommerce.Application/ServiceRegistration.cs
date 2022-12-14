using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddMediatR(typeof(ServiceRegistration));
            //burada şunu diyoruz. Mediatr kütüphanesiden yararlanarak, sen bu assembly (yani bu katman içindeki request response classlarını al ve program cs e bildir.)
            collection.AddHttpClient();
        }
    }
}
