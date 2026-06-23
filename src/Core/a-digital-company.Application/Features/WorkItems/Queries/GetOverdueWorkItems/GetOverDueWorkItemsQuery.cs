using a-digital-company.Application.Models.WorkItem;
using MediatR;

namespace a-digital-company.Application.Features.WorkItems.Queries.GetOverdueWorkItems
{
    public record GetOverdueWorkItemsQuery() : IRequest<List<WorkItemDto>>;
}