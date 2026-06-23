using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using a-digital-company.Application.Interfaces.Identity;
using MediatR;

namespace a-digital-company.Application.Features.Users.Commands.AssignRole
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