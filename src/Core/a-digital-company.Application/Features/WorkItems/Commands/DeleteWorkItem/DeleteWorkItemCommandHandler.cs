using a_digital_company.Application.Exceptions;
using a_digital_company.Application.Interfaces.Logging;
using a_digital_company.Application.Interfaces.Persistence;
using a_digital_company.Domain;
using MediatR;

namespace a_digital_company.Application.Features.WorkItems.Commands.DeleteWorkItem
{
    public class DeleteWorkItemCommandHandler(IWorkItemRepository workItemRepository, IAppLogger<DeleteWorkItemCommandHandler> logger) : IRequestHandler<DeleteWorkItemCommand, Unit>
    {
        private readonly IWorkItemRepository _workItemRepository = workItemRepository;
        private readonly IAppLogger<DeleteWorkItemCommandHandler> _logger = logger;
        public async Task<Unit> Handle(DeleteWorkItemCommand request, CancellationToken cancellationToken)
        {
            var workItem = await _workItemRepository.GetByIdAsync(request.Id);

            if (workItem is null)
            {
                _logger.LogWarning("Delete failed. WorkItem {WorkItemId} not found", request.Id);
                throw new NotFoundException(nameof(WorkItem), request.Id);
            }

            await _workItemRepository.DeleteAsync(workItem);
            _logger.LogInformation("WorkItem {WorkItemId} deleted", request.Id);
            return Unit.Value;
        }
    }
}