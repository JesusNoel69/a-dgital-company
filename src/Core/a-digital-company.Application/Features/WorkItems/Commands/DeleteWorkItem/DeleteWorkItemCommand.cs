using MediatR;

namespace a-digital-company.Application.Features.WorkItems.Commands.DeleteWorkItem
{
    public class DeleteWorkItemCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}