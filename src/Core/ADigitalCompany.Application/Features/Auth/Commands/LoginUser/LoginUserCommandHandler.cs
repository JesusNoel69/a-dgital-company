using ADigitalCompany.Application.Interfaces.Identity;
using ADigitalCompany.Application.Models.Identity;
using MediatR;

namespace ADigitalCompany.Application.Features.Auth.Commands.LoginUser
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