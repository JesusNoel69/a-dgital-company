using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using a_digital_company.Application.Interfaces.Identity;
using MediatR;

namespace a_digital_company.Application.Features.Users.Commands.AssignRole
{
    public class AssignRoleCommandHandler(IUserService _userService) : IRequestHandler<AssignRoleCommand, Unit>
    {
        public async Task<Unit> Handle(AssignRoleCommand request, CancellationToken cancellationToken)
        {
            await _userService.AssignRole(request.UserId, request.Role);
            return Unit.Value;
        }
    }
}