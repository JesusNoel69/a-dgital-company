using AutoMapper;
using a_digital_company.Application.Exceptions;
using a_digital_company.Application.Interfaces.Identity;
using a_digital_company.Application.Interfaces.Persistence;
using a_digital_company.Application.Models.WorkItem;
using a_digital_company.Domain;
using MediatR;

namespace a_digital_company.Application.Features.WorkItems.Queries.GetWorkItemById
{
    public class GetWorkItemByIdQueryHandler(IWorkItemRepository workItemRepository, IMapper mapper, IUserService userService) : IRequestHandler<GetWorkItemByIdQuery, WorkItemDto>
    {
        private readonly IWorkItemRepository _workItemRepository = workItemRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IUserService _userService = userService;

        public async Task<WorkItemDto> Handle(GetWorkItemByIdQuery request, CancellationToken cancellationToken)
        {
           var workItem = await _workItemRepository.GetByIdAndUserId(request.Id, _userService.UserId!);

            if (workItem is null)
            {
                throw new NotFoundException(nameof(WorkItem), request.Id);
            }

            return _mapper.Map<WorkItemDto>(workItem);
        }
    }
}