using a-digital-company.Application.Interfaces.Identity;
using a-digital-company.Application.Models.Identity;
using MediatR;

namespace a-digital-company.Application.Features.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler(IUserService _userService) : IRequestHandler<GetUsersQuery, List<User>>
    {
        public async Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
           return await _userService.GetUsers();
        }
    }
}