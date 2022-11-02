using ECommerce.Application.Repositories.ProductImageFile;
using ECommerce.Persistance.Contexts;

namespace ECommerce.Persistance.Repositories.ProductImageRepository
{
    public class ProductImageReadRepository : ReadRepository<ECommerce.Domain.Entities.ProductImageFile>, IProductImageFileReadRepository
    {
        public ProductImageReadRepository(ECommerceAPIDbContext context) : base(context)
        {
        }
    }
}
