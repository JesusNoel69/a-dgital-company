using AutoMapper;
using a_digital_company.Application.Exceptions;
using a_digital_company.Application.Interfaces.Logging;
using a_digital_company.Application.Interfaces.Persistence;
using a_digital_company.Application.Models.WorkItem;
using a_digital_company.Domain;
using MediatR;

namespace a_digital_company.Application.Features.WorkItems.Commands.UpdateWorkItem
{
    public class UpdateWorkItemCommandHandler(IMapper mapper, IWorkItemRepository workItemRepository, IAppLogger<UpdateWorkItemCommandHandler> logger) : IRequestHandler<UpdateWorkItemCommand, WorkItemDto>
    { 
        private readonly IMapper _mapper = mapper;
        private readonly IWorkItemRepository _workItemRepository = workItemRepository;
        private readonly IAppLogger<UpdateWorkItemCommandHandler> _logger = logger;

        public async Task<WorkItemDto> Handle(UpdateWorkItemCommand request, CancellationToken cancellationToken)
        {
            var workItem = await _workItemRepository.GetByIdAsync(request.Id);
            if (workItem is null)
            {
                _logger.LogWarning("Update failed. WorkItem {WorkItemId} not found", request.Id);
                throw new NotFoundException(nameof(WorkItem), request.Id);
            }
            _mapper.Map(request, workItem);
            await _workItemRepository.UpdateAsync(workItem);
            _logger.LogInformation("WorkItem {WorkItemId} updated", workItem.Id);
            return _mapper.Map<WorkItemDto>(workItem);
        }
    }
}