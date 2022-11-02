using ECommerce.Application.Repositories;
using ECommerce.Application.Repositories.FileRepository;
using ECommerce.Persistance.Contexts;

namespace ECommerce.Persistance.Repositories.FileRepository
{
    public class FileWriteRepository : WriteRepository<ECommerce.Domain.Entities.File>, IFileWriteRepository
    {
        public FileWriteRepository(ECommerceAPIDbContext context) : base(context)
        {
        }
    }
}
