using ADigitalCompany.Application.Interfaces.Identity;
using ADigitalCompany.Application.Models.Identity;
using MediatR;

namespace ADigitalCompany.Application.Features.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler(IUserService _userService) : IRequestHandler<GetUsersQuery, List<User>>
    {
        public async Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
           return await _userService.GetUsers();
        }
    }
}