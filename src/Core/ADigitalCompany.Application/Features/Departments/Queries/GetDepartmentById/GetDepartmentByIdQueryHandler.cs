using ADigitalCompany.Application.Exceptions;
using ADigitalCompany.Application.Interfaces.Identity;
using ADigitalCompany.Application.Interfaces.Persistence;
using ADigitalCompany.Application.Models.Department;
using ADigitalCompany.Domain;
using AutoMapper;
using MediatR;

namespace ADigitalCompany.Application.Features.Departments.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQueryHandler(IDepartmentRepository departmentRepository, IUserService userService, IMapper mapper) : IRequestHandler<GetDepartmentByIdQuery, DepartmentDto>
    {
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IUserService _userService = userService;
        public async Task<DepartmentDto> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetByIdAsync(request.Id);
            if (department is null)
            {
                throw new NotFoundException(nameof(Department), request.Id);
            }
            var dto = _mapper.Map<DepartmentDto>(department);
            if (!string.IsNullOrEmpty(department.ResponsibleId))
            {
                var manager = await _userService.GetUser(department.ResponsibleId);
                dto.Manager = new UserSummaryDto()
                {
                  Email=manager.Email,
                  FullName = $"{manager.FirstName} {manager.LastName}",
                  Id=manager.Id,
                };  
            }
            return dto;
        }
    }
}