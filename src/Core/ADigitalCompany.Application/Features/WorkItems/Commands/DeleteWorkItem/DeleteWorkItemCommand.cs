using MediatR;

namespace ADigitalCompany.Application.Features.WorkItems.Commands.DeleteWorkItem
{
    public class DeleteWorkItemCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}