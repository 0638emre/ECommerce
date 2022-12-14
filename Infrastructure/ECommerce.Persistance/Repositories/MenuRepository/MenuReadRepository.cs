using ECommerce.Application.Repositories.MenuRepository;
using ECommerce.Persistance.Contexts;

namespace ECommerce.Persistance.Repositories.MenuRepository;

public class MenuReadRepository : ReadRepository<Domain.Entities.Menu>, IMenuReadRepository
{
    public MenuReadRepository(ECommerceAPIDbContext context) : base(context)
    {
    }
}