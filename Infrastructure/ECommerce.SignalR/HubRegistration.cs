using ECommerce.SignalR.Hubs;
using Microsoft.AspNetCore.Builder;

namespace ECommerce.SignalR;

//bu class hublarımızı program.cs de tek tek yazmak yerine buradan yazılıp program.cs e gönderilecektir.
public static class HubRegistration
{
    public static void MapHubs(this WebApplication webApplication)
    {
        webApplication.MapHub<ProductHub>("/products-hub");
    }
}