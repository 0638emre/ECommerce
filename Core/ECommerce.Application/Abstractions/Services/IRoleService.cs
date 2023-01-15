using Microsoft.AspNetCore.Identity;

namespace ECommerce.Application.Abstractions.Services
{
    public interface IRoleService
    {
        Task<bool> CreateRoleAsync(string name);
        Task<bool> DeleteRoleAsync(string name);
        Task<bool> UpdateAsync(string id, string name);
    }
}
