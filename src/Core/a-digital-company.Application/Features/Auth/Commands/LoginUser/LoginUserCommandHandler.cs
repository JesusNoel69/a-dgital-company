using a_digital_company.Application.Interfaces.Identity;
using a_digital_company.Application.Models.Identity;
using MediatR;

namespace a_digital_company.Application.Features.Auth.Commands.LoginUser
{
    public class LoginUserCommandHandler(IAuthService authService)
        : IRequestHandler<LoginUserCommand, AuthResponse>
    {
        private readonly IAuthService _authService = authService;
        public async Task<AuthResponse> Handle(
            LoginUserCommand request,
            CancellationToken cancellationToken)
        {
            return await _authService.Login(new AuthRequest
            {
                Email=request.Email,
                Password=request.Password,
            });
        }
    }
}