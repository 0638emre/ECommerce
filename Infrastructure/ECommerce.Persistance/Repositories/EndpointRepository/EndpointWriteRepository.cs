using ECommerce.Application.Repositories.EndpointRepository;
using ECommerce.Domain.Entities;
using ECommerce.Persistance.Contexts;

namespace ECommerce.Persistance.Repositories.EndpointRepository;


public class EndpointWriteRepository : WriteRepository<Endpoint>, IEndpointWriteRepository
{
    public EndpointWriteRepository(ECommerceAPIDbContext context) : base(context)
    {
    }
}