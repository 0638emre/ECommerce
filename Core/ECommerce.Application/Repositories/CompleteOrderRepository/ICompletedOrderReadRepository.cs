using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerce.Application.Repositories.CompleteOrderRepository
{
    public interface ICompletedOrderReadRepository : IReadRepository<CompletedOrder>
    {
     
    }
}
