using a-digital-company.Application.Models.WorkItem;
using a-digital-company.Domain;
using MediatR;

namespace a-digital-company.Application.Features.WorkItems.Queries.GetMyWorkItems
{
    public record GetMyWorkItemsQuery() : IRequest<List<WorkItemDto>>;
}