using ECommerce.Application.Repositories.InvoiceFile;
using ECommerce.Persistance.Contexts;

namespace ECommerce.Persistance.Repositories.InvoiceFileRepository
{
    public class InvoiceFileWriteRepository : WriteRepository<ECommerce.Domain.Entities.InvoiceFile>, IInvoiceFileWriteRepository
    {
        public InvoiceFileWriteRepository(ECommerceAPIDbContext context) : base(context)
        {
        }
    }
}
