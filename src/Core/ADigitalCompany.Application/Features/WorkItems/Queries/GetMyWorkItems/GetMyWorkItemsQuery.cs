using ADigitalCompany.Application.Models.WorkItem;
using ADigitalCompany.Domain;
using MediatR;

namespace ADigitalCompany.Application.Features.WorkItems.Queries.GetMyWorkItems
{
    public record GetMyWorkItemsQuery() : IRequest<List<WorkItemDto>>;
}