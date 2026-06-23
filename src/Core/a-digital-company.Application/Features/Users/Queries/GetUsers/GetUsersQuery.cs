using a_digital_company.Application.Models.Identity;
using MediatR;

namespace a_digital_company.Application.Features.Users.Queries.GetUsers
{
    public record GetUsersQuery() : IRequest<List<User>>;
}