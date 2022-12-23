using ECommerce.Application.Repositories.BasketItemRepository;
using ECommerce.Domain.Entities;
using ECommerce.Persistance.Contexts;

namespace ECommerce.Persistance.Repositories.BasketItemRepository
{
    public class BasketItemReadRepository : ReadRepository<BasketItem>, IBasketItemReadRepository
    {
        public BasketItemReadRepository(ECommerceAPIDbContext context) : base(context)
        {
        }
    }
}
