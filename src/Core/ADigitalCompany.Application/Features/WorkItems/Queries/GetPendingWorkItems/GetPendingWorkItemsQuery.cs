using ADigitalCompany.Application.Models.WorkItem;
using MediatR;

namespace ADigitalCompany.Application.Features.WorkItems.Queries.GetPendingWorkItems
{
    public record GetPendingWorkItemsQuery() : IRequest<List<WorkItemDto>>;
}