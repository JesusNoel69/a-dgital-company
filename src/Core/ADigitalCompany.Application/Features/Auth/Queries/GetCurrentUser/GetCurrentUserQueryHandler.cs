using ADigitalCompany.Application.Interfaces.Identity;
using ADigitalCompany.Application.Models.Identity;
using MediatR;

namespace ADigitalCompany.Application.Features.Auth.Queries.GetCurrentUser
{
    public class GetCurrentUserQueryHandler(IUserService _userService) : IRequestHandler<GetCurrentUserQuery, User>
    {
        public async Task<User> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var userId = _userService.UserId;

            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new UnauthorizedAccessException();
            }

            return await _userService.GetUser(userId);
        }
    }
}