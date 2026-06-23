using a-digital-company.Application.Models.WorkItem;
using a-digital-company.Domain;
using MediatR;

namespace a-digital-company.Application.Features.WorkItems.Queries.GetWorkItemById
{
    public record GetWorkItemByIdQuery(int Id) : IRequest<WorkItemDto>;
}