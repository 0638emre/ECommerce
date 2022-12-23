using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Hosting;

namespace ECommerce.Application.Repositories.BasketItemRepository
{
    public interface IBasketItemWriteRepository : IWriteRepository<BasketItem>
    {
    }
}
