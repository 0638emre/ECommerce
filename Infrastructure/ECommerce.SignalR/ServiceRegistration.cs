using ECommerce.Application.Abstraction.Hubs;
using ECommerce.SignalR.HubServices;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.SignalR;

public static class ServiceRegistration
{
    public static void AddSignalRServices(this IServiceCollection collection)
    {
        collection.AddTransient<IProductHubService, ProductHubService>();
        collection.AddSignalR();
    }
}