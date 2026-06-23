using a-digital-company.Domain.Enums;
using MediatR;

namespace a-digital-company.Application.Features.WorkItems.Commands.ChangePriority
{
    public class ChangePriorityCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public WorkItemPriority Priority { get; set; }
    }
}