using ECommerce.Application.Repositories.EndpointRepository;
using ECommerce.Domain.Entities;
using ECommerce.Persistance.Contexts;

namespace ECommerce.Persistance.Repositories.EndpointRepository;

public class EndpointReadRepository : ReadRepository<Endpoint>, IEndpointReadRepository
{
    public EndpointReadRepository(ECommerceAPIDbContext context) : base(context)
    {
    }
}