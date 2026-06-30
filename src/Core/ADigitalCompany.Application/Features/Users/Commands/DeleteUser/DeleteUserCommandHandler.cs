using ADigitalCompany.Application.Interfaces.Identity;
using MediatR;

namespace ADigitalCompany.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler(IUserService _userService) : IRequestHandler<DeleteUserCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _userService.DeleteUser(request.Id);
            return Unit.Value;
        }
    }
}