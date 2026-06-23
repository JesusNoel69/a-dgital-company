using a-digital-company.Application.Models.Identity;
using MediatR;

namespace a-digital-company.Application.Features.Users.Queries.GetUserById
{
    public record GetUserByIdQuery(string Id) : IRequest<User>;
}