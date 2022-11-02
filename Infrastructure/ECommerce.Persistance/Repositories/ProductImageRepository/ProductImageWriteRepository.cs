using ECommerce.Application.Repositories.ProductImageFile;
using ECommerce.Persistance.Contexts;

namespace ECommerce.Persistance.Repositories.ProductImageRepository
{
    public class ProductImageWriteRepository : WriteRepository<ECommerce.Domain.Entities.ProductImageFile>, IProductImageFileWriteRepository
    {
        public ProductImageWriteRepository(ECommerceAPIDbContext context) : base(context)
        {
        }
    }
}
