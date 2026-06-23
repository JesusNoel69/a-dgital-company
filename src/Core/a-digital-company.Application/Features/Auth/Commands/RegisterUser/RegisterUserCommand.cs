using a_digital_company.Application.Models.Identity;
using MediatR;

namespace a_digital_company.Application.Features.Auth.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<RegistrationResponse>
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string UserName { get; set; } = default!;

    }
}