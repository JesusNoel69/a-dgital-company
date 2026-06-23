using MediatR;

namespace a_digital_company.Application.Features.WorkItems.Commands.DeleteWorkItem
{
    public class DeleteWorkItemCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}