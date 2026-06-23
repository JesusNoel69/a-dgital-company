using a_digital_company.Application.Models.WorkItem;
using MediatR;

namespace a_digital_company.Application.Features.WorkItems.Queries.GetPendingWorkItems
{
    public record GetPendingWorkItemsQuery() : IRequest<List<WorkItemDto>>;
}