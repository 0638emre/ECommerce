using ECommerce.Application.Abstractions.Services;
using ECommerce.Application.DTOs.User;
using MediatR;

namespace ECommerce.Application.Features.Queries.AppUser.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQueryRequest, GetAllUsersQueryResponse>
    {
        private readonly IUserService _userService;

        public GetAllUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetAllUsersQueryResponse> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
        {
            List<ListUser> users = await  _userService.GetAllUsersAsync(request.Page, request.Size);

            return new GetAllUsersQueryResponse
            {
                Users = users,
                TotalUsersCount = _userService.TotalUsersCount
            };
        }
    }
}
