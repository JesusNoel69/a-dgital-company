using ADigitalCompany.Application.Models.WorkItem;
using MediatR;

namespace ADigitalCompany.Application.Features.WorkItems.Queries.GetOverdueWorkItems
{
    public record GetOverdueWorkItemsQuery() : IRequest<List<WorkItemDto>>;
}