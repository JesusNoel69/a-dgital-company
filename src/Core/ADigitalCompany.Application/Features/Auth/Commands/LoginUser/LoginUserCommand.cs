using ADigitalCompany.Application.Models.Identity;
using MediatR;

namespace ADigitalCompany.Application.Features.Auth.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<AuthResponse>
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}