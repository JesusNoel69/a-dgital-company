using a_digital_company.Application.Models.Identity;
using MediatR;

namespace a_digital_company.Application.Features.Users.Queries.GetUserById
{
    public record GetUserByIdQuery(string Id) : IRequest<User>;
}