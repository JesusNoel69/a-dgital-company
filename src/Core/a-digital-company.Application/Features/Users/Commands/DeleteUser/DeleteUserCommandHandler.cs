using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using a_digital_company.Application.Interfaces.Identity;
using MediatR;

namespace a_digital_company.Application.Features.Users.Commands.DeleteUser
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