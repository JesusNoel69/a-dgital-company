using FluentValidation;

namespace ADigitalCompany.Application.Features.WorkItems.Commands.ChangePriority
{
    public class ChangePriorityCommandValidator : AbstractValidator<ChangePriorityCommand>
    {
        public ChangePriorityCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);
        }
    }
}