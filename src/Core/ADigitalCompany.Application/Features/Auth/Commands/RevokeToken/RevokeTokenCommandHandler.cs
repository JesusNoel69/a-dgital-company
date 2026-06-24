using ADigitalCompany.Application.Interfaces.Identity;
using ADigitalCompany.Application.Models.Identity;
using MediatR;

namespace ADigitalCompany.Application.Features.Auth.Commands.RevokeToken
{
    public class RevokeTokenCommandHandler(
         IAuthService authService)
        : IRequestHandler<RevokeTokenCommand, Unit>
    {
        private readonly IAuthService _authService = authService;
        public async Task<Unit> Handle(
            RevokeTokenCommand request,
            CancellationToken cancellationToken)
        {
            await _authService.RevokeTokenAsync(request.RefreshToken);
            return Unit.Value;
        }
    }
}