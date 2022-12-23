using ECommerce.Application.Repositories.BasketItemRepository;
using ECommerce.Application.Repositories.BasketRepository;
using ECommerce.Domain.Entities;
using ECommerce.Persistance.Contexts;

namespace ECommerce.Persistance.Repositories.BasketRepository
{
    public class BasketReadRepository : ReadRepository<Basket>, IBasketReadRepository
    {
        public BasketReadRepository(ECommerceAPIDbContext context) : base(context)
        {
        }
    }
}
