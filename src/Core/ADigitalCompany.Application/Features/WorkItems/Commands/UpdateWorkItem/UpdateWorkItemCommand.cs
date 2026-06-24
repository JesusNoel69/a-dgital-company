using ADigitalCompany.Application.Models.WorkItem;
using ADigitalCompany.Domain.Enums;
using MediatR;

namespace ADigitalCompany.Application.Features.WorkItems.Commands.UpdateWorkItem
{
    public class UpdateWorkItemCommand: IRequest<WorkItemDto>
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public WorkItemPriority Priority { get; set; }
        public WorkItemStatus Status { get; set; }
    }
}