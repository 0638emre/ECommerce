using ECommerce.Application.Repositories.MenuRepository;
using ECommerce.Persistance.Contexts;

namespace ECommerce.Persistance.Repositories.MenuRepository;

public class MenuWriteRepository: WriteRepository<Domain.Entities.Menu>, IMenuWriteRepository
{
    public MenuWriteRepository(ECommerceAPIDbContext context) : base(context)
    {
    }
}