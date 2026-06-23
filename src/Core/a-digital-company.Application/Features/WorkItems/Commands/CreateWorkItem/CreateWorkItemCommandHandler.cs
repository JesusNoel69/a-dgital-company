using AutoMapper;
using a_digital_company.Application.Exceptions;
using a_digital_company.Application.Interfaces.Logging;
using a_digital_company.Application.Interfaces.Persistence;
using a_digital_company.Application.Models.WorkItem;
using a_digital_company.Domain;
using MediatR;

namespace a_digital_company.Application.Features.WorkItems.Commands.CreateWorkItem
{
    public class CreateWorkItemCommandHandler(IMapper mapper, IWorkItemRepository workItemRepository, IAppLogger<CreateWorkItemCommandHandler> logger)
        : IRequestHandler<CreateWorkItemCommand, WorkItemDto>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IWorkItemRepository _workItemRepository = workItemRepository;
        private readonly IAppLogger<CreateWorkItemCommandHandler> _logger = logger;

        public async Task<WorkItemDto> Handle(CreateWorkItemCommand request, CancellationToken cancellationToken)
        {
            var exists = await _workItemRepository.WorkItemExists(request.UserId, request.Title);
            
            if (exists)
            {
                _logger.LogWarning("WorkItem creation failed. User {UserId} already has a work item with title {Title}", request.UserId, request.Title);
                throw new BadRequestException("A work item with this title already exists.");
            }

            var workItem = _mapper.Map<WorkItem>(request);

            await _workItemRepository.CreateAsync(workItem);

            _logger.LogInformation("WorkItem {WorkItemId} created for user {UserId}", workItem.Id, workItem.UserId);

            return _mapper.Map<WorkItemDto>(workItem);
            
        }
    }
}