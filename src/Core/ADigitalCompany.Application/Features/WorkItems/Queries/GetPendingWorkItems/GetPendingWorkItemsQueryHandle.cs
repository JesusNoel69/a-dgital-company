using AutoMapper;
using ADigitalCompany.Application.Interfaces.Identity;
using ADigitalCompany.Application.Interfaces.Persistence;
using ADigitalCompany.Application.Models.WorkItem;
using MediatR;

namespace ADigitalCompany.Application.Features.WorkItems.Queries.GetPendingWorkItems
{
    public class GetPendingWorkItemsQueryHandler(IWorkItemRepository workItemRepository, IMapper mapper, IUserService userService) : IRequestHandler<GetPendingWorkItemsQuery, List<WorkItemDto>>
    {
        private readonly IWorkItemRepository _workItemRepository = workItemRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IUserService _userService = userService;

        public async Task<List<WorkItemDto>> Handle(GetPendingWorkItemsQuery request, CancellationToken cancellationToken)
        {
            var workItem = await _workItemRepository.GetPendingByUserId(_userService.UserId);
            return _mapper.Map<List<WorkItemDto>>(workItem);
        }
    }
}