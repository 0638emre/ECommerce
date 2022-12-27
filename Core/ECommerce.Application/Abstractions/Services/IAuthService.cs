using ECommerce.Application.Abstractions.Services.Authentications;

namespace ECommerce.Application.Abstractions;

public interface IAuthService : IExternalAuthentication, IInternalAuthentication
{
    Task PasswordResetAsnyc(string email);
    Task<bool> VerifyResetTokenAsync(string resetToken, string userId);
}