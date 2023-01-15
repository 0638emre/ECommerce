using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Repositories.CompleteOrderRepository
{
    public interface ICompletedOrderWriteRepository : IWriteRepository<CompletedOrder>
    {
       
    }
}
