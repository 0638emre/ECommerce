using ECommerce.Application.DTOs.Configuration;

namespace ECommerce.Application.Abstraction.Services.Configurations;

public interface IApplicationService
{
    List<Menu> GetAuthorizeDefinitionEndpoints(Type type);
}