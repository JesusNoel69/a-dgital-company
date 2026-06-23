using a-digital-company.Application.Exceptions;
using a-digital-company.Application.Interfaces.Identity;
using a-digital-company.Application.Models.Identity;
using MediatR;

namespace a-digital-company.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler(IUserService _userService) : IRequestHandler<GetUserByIdQuery, User>
    {
        public async Task<User?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUser(request.Id);

            if (user is null)
            {
                throw new NotFoundException("User",request.Id);
            }
            return user;
        }
    }
}