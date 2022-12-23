using ECommerce.Application.Repositories.BasketItemRepository;
using ECommerce.Domain.Entities;
using ECommerce.Persistance.Contexts;

namespace ECommerce.Persistance.Repositories.BasketItemRepository
{
    public class BasketItemWriteRepository : WriteRepository<BasketItem>, IBasketItemWriteRepository
    {
        public BasketItemWriteRepository(ECommerceAPIDbContext context) : base(context)
        {
        }
    }
}
