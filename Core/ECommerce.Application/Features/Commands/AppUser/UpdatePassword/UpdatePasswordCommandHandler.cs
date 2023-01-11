using ECommerce.Application.Abstractions.Services;
using ECommerce.Application.Exceptions;
using MediatR;

namespace ECommerce.Application.Features.Commands.AppUser.UpdatePassword
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommandRequest, UpdatePasswordCommandResponse>
    {
        readonly IUserService _userService;

        public UpdatePasswordCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UpdatePasswordCommandResponse> Handle(UpdatePasswordCommandRequest request, CancellationToken cancellationToken)
        {
            if (!request.NewPassword.Equals(request.PasswordConfirm))
            {
                throw new PasswordChangeFailedException("Lütfe şifreyi doğrulayınız");
            }

            await _userService.UpdatePasswordAsync(request.UserId, request.ResetToken, request.NewPassword);

            return new();
        }
    }
}
