using a_digital_company.Application.Interfaces.Identity;
using a_digital_company.Application.Models.Identity;
using MediatR;

namespace a_digital_company.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler(
        IAuthService authService)
        : IRequestHandler<RefreshTokenCommand, AuthResponse>
    {
        private readonly IAuthService _authService = authService;
        public async Task<AuthResponse> Handle(
            RefreshTokenCommand request,
            CancellationToken cancellationToken)
        {
            return await _authService.RefreshTokenAsync(request.RefreshToken);
        }
    }
}