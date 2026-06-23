using a_digital_company.Application.Interfaces.Identity;
using a_digital_company.Application.Models.Identity;
using MediatR;

namespace a_digital_company.Application.Features.Auth.Queries.GetCurrentUser
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