using ADigitalCompany.Application.Models.Identity;
using MediatR;

namespace ADigitalCompany.Application.Features.Users.Queries.GetUsers
{
    public record GetUsersQuery() : IRequest<List<User>>;
}