using ADigitalCompany.Application.Exceptions;
using ADigitalCompany.Application.Interfaces.Logging;
using ADigitalCompany.Application.Interfaces.Persistence;
using ADigitalCompany.Domain;
using MediatR;

namespace ADigitalCompany.Application.Features.WorkItems.Commands.ChangePriority
{
    public class ChangePriorityCommandHandler(IWorkItemRepository workItemRepository, IAppLogger<ChangePriorityCommandHandler> logger) : IRequestHandler<ChangePriorityCommand, Unit>
    {
        private readonly IWorkItemRepository _workItemRepository = workItemRepository;
        private readonly IAppLogger<ChangePriorityCommandHandler> _logger = logger;

        public async Task<Unit> Handle(ChangePriorityCommand request, CancellationToken cancellationToken)
        {
            var workItem = await _workItemRepository.GetByIdAsync(request.Id);
            if (workItem is null)
            {
                throw new NotFoundException(nameof(WorkItem), request.Id);
            }
            var oldPriority = workItem.Priority;
            workItem.ChangePriority(request.Priority);
            await _workItemRepository.UpdateAsync(workItem);
            _logger.LogInformation("WorkItem {WorkItemId} priority changed from {OldPriority} to {NewPriority}", workItem.Id, oldPriority, request.Priority);
            return Unit.Value;
        }
    }
}