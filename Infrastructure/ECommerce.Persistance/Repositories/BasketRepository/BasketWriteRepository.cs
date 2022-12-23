using ECommerce.Application.Repositories.BasketRepository;
using ECommerce.Domain.Entities;
using ECommerce.Persistance.Contexts;

namespace ECommerce.Persistance.Repositories.BasketRepository
{
    public class BasketWriteRepository : WriteRepository<Basket>, IBasketWriteRepository
    {
        public BasketWriteRepository(ECommerceAPIDbContext context) : base(context)
        {
        }
    }
}
