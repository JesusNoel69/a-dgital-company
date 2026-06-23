using a_digital_company.Application.Interfaces.Identity;
using a_digital_company.Application.Models.Identity;
using MediatR;

namespace a_digital_company.Application.Features.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler(IUserService _userService) : IRequestHandler<GetUsersQuery, List<User>>
    {
        public async Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
           return await _userService.GetUsers();
        }
    }
}