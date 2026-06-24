using ADigitalCompany.Application.Exceptions;
using ADigitalCompany.Application.Interfaces.Logging;
using ADigitalCompany.Application.Interfaces.Persistence;
using ADigitalCompany.Domain;
using MediatR;

namespace ADigitalCompany.Application.Features.WorkItems.Commands.CompleteWorkItem
{
    public class CompleteWorkItemCommandHandler(IWorkItemRepository workItemRepository, IAppLogger<CompleteWorkItemCommandHandler> logger)
        : IRequestHandler<CompleteWorkItemCommand, Unit>
    {
        private readonly IWorkItemRepository _workItemRepository = workItemRepository;
        private readonly IAppLogger<CompleteWorkItemCommandHandler> _logger = logger;
        
        public async Task<Unit> Handle(CompleteWorkItemCommand request, CancellationToken cancellationToken)
        {
            var workItem = await _workItemRepository.GetByIdAsync(request.Id);

            if (workItem is null)
            {
                _logger.LogWarning("Complete failed. WorkItem {WorkItemId} not found", request.Id);
                throw new NotFoundException(nameof(WorkItem), request.Id);
            }
            workItem.Complete();

            await _workItemRepository.UpdateAsync(workItem);
            _logger.LogInformation("WorkItem {WorkItemId} completed", workItem.Id);
            return Unit.Value;
        }
    }
}