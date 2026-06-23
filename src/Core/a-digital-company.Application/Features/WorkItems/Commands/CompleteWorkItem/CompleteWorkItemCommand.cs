using MediatR;

namespace a_digital_company.Application.Features.WorkItems.Commands.CompleteWorkItem
{
    public class CompleteWorkItemCommand : IRequest<Unit>
    {
        public int Id {get; set;}
    }
}