using a_digital_company.Application.Models.WorkItem;
using a_digital_company.Domain;
using MediatR;

namespace a_digital_company.Application.Features.WorkItems.Queries.GetWorkItemById
{
    public record GetWorkItemByIdQuery(int Id) : IRequest<WorkItemDto>;
}