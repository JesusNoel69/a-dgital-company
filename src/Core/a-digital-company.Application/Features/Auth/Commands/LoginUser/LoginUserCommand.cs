using a_digital_company.Application.Models.Identity;
using MediatR;

namespace a_digital_company.Application.Features.Auth.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<AuthResponse>
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}