using a_digital_company.Application.Models.WorkItem;
using a_digital_company.Domain;
using MediatR;

namespace a_digital_company.Application.Features.WorkItems.Queries.GetMyWorkItems
{
    public record GetMyWorkItemsQuery() : IRequest<List<WorkItemDto>>;
}