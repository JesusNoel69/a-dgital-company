using ADigitalCompany.Domain.Enums;
using MediatR;

namespace ADigitalCompany.Application.Features.WorkItems.Commands.ChangePriority
{
    public class ChangePriorityCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public WorkItemPriority Priority { get; set; }
    }
}