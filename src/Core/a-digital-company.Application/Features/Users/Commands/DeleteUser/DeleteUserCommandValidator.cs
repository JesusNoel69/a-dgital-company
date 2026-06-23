using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace a_digital_company.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandValidator
        : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}