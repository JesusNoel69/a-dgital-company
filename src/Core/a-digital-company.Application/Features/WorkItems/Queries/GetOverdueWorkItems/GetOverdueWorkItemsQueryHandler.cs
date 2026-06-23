using a-digital-company.Application.Interfaces.Persistence;
using a-digital-company.Application.Models.WorkItem;
using AutoMapper;
using MediatR;
using a-digital-company.Application.Interfaces.Identity;

namespace a-digital-company.Application.Features.WorkItems.Queries.GetOverdueWorkItems
{
    public class GetOverdueWorkItemsQueryHandler(IWorkItemRepository workItemRepository, IMapper mapper, IUserService userService) : IRequestHandler<GetOverdueWorkItemsQuery, List<WorkItemDto>>
    {
        private readonly IWorkItemRepository _workItemRepository = workItemRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IUserService _userService = userService;
        public async Task<List<WorkItemDto>> Handle(GetOverdueWorkItemsQuery request, CancellationToken cancellationToken)
        {
            var overDueWorkItems = await _workItemRepository.GetOverdueByUserId(_userService.UserId);
            return _mapper.Map<List<WorkItemDto>>(overDueWorkItems);
        }
    }
}