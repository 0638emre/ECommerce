using ECommerce.Application.Abstraction.Services.Authentications;

namespace ECommerce.Application.Abstraction;

public interface IAuthService : IExternalAuthentication, IInternalAuthentication
{
    Task PasswordResetAsnyc(string email);
    Task<bool> VerifyResetTokenAsync(string resetToken, string userId);
}