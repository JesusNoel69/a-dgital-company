using ADigitalCompany.Application.Models.WorkItem;
using ADigitalCompany.Domain;
using MediatR;

namespace ADigitalCompany.Application.Features.WorkItems.Queries.GetWorkItemById
{
    public record GetWorkItemByIdQuery(int Id) : IRequest<WorkItemDto>;
}