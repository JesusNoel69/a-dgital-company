using ADigitalCompany.Application.Interfaces.Identity;
using ADigitalCompany.Application.Interfaces.Persistence;
using ADigitalCompany.Application.Models.Department;
using AutoMapper;
using MediatR;

namespace ADigitalCompany.Application.Features.Departments.Queries.GetDepartments
{
    public class GetDepartmentsQueryHandler(IDepartmentRepository departmentRepository, IUserService userService, IMapper mapper) : IRequestHandler<GetDepartmentsQuery, IReadOnlyList<DepartmentDto>>
    {
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IUserService _userService = userService;
        public async Task<IReadOnlyList<DepartmentDto>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var departments = await _departmentRepository.GetAsync();
            var managers = await _userService.GetUsers();
            var managersDictionary = managers.ToDictionary(x => x.Id);

            var dtoList = _mapper.Map<List<DepartmentDto>>(departments);
            foreach (var dto in dtoList)
            {
                if (string.IsNullOrWhiteSpace(dto.Manager?.Id))
                    continue;

                if (managersDictionary.TryGetValue(dto.Manager.Id, out var manager))
                {
                    dto.Manager = new UserSummaryDto
                    {
                        Id = manager.Id,
                        Email = manager.Email,
                        FullName = $"{manager.FirstName} {manager.LastName}"
                    };
                }
            }
            return dtoList;
        }
    }
}