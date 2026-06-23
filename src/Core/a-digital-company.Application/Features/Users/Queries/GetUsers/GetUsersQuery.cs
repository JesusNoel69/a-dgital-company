using a-digital-company.Application.Models.Identity;
using MediatR;

namespace a-digital-company.Application.Features.Users.Queries.GetUsers
{
    public record GetUsersQuery() : IRequest<List<User>>;
}