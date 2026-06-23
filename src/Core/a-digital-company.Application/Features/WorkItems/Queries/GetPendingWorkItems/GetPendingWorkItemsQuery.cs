using a-digital-company.Application.Models.WorkItem;
using MediatR;

namespace a-digital-company.Application.Features.WorkItems.Queries.GetPendingWorkItems
{
    public record GetPendingWorkItemsQuery() : IRequest<List<WorkItemDto>>;
}