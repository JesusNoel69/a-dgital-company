using FluentValidation;

namespace a_digital_company.Application.Features.Users.Commands.AssignRole
{
    public class AssignRoleCommandValidator : AbstractValidator<AssignRoleCommand>
    {
        public AssignRoleCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty();

            RuleFor(x => x.Role)
                .NotEmpty();
        }
    }
}