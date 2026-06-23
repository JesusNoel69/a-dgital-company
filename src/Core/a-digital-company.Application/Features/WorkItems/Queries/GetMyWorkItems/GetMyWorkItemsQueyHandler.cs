using AutoMapper;
using a_digital_company.Application.Interfaces.Identity;
using a_digital_company.Application.Interfaces.Persistence;
using a_digital_company.Application.Models.WorkItem;
using MediatR;

namespace a_digital_company.Application.Features.WorkItems.Queries.GetMyWorkItems
{
    public class GetMyWorkItemsQueryHandler(IWorkItemRepository workItemRepository, IMapper mapper, IUserService userService) : IRequestHandler<GetMyWorkItemsQuery, List<WorkItemDto>>
    {
        private readonly IWorkItemRepository _workItemRepository = workItemRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IUserService _userService = userService;

        public async Task<List<WorkItemDto>> Handle(GetMyWorkItemsQuery request, CancellationToken cancellationToken)
        {
            var itemWork = await _workItemRepository.GetByUserId(_userService.UserId);
            return _mapper.Map<List<WorkItemDto>>(itemWork);
        }
    }
}