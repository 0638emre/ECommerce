using ECommerce.Application.Repositories.OrderRepository;
using ECommerce.Domain.Entities;
using ECommerce.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistance.Repositories.OrderRepository
{
    public class OrderReadRepository : ReadRepository<Order>,
        IOrderReadRepository
    {
        public OrderReadRepository(ECommerceAPIDbContext context) : base(context)
        {
        }
    }
}
