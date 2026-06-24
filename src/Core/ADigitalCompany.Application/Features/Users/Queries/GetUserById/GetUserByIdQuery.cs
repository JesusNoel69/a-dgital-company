using ADigitalCompany.Application.Models.Identity;
using MediatR;

namespace ADigitalCompany.Application.Features.Users.Queries.GetUserById
{
    public record GetUserByIdQuery(string Id) : IRequest<User>;
}