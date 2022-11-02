using ECommerce.Application.Repositories.InvoiceFile;
using ECommerce.Persistance.Contexts;

namespace ECommerce.Persistance.Repositories.InvoiceFileRepository
{
    public class InvoiceFileReadRepository : ReadRepository<ECommerce.Domain.Entities.InvoiceFile>, IInvoiceFileReadRepository
    {
        public InvoiceFileReadRepository(ECommerceAPIDbContext context) : base(context)
        {
        }
    }
}
