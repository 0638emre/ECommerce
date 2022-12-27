using ECommerce.Application.Abstractions;
using ECommerce.Application.Abstractions.Token;
using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Commands.AppUser.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommandRequest, RefreshTokenLoginCommandResponse>
    {
        private IAuthService _authService;

        public RefreshTokenLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<RefreshTokenLoginCommandResponse> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
        {
            Token token =await  _authService.RefreshTokenLoginAsync(request.RefreshToken);

            return new()
            {
                Token = token
            };
        }
    }
}
