using ECommerce.Application.Repositories.FileRepository;
using ECommerce.Persistance.Contexts;

namespace ECommerce.Persistance.Repositories.FileRepository
{
    public class FileReadRepository : ReadRepository<ECommerce.Domain.Entities.File>, IFileReadRepository
    {
        public FileReadRepository(ECommerceAPIDbContext context) : base (context)
        {

        }
    }
}
