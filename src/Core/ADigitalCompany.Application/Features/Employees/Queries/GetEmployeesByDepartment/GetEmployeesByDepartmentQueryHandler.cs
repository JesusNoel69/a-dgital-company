using ADigitalCompany.Application.Interfaces.Identity;
using ADigitalCompany.Application.Interfaces.Persistence;
using ADigitalCompany.Application.Models.Employee;
using AutoMapper;
using MediatR;

namespace ADigitalCompany.Application.Features.Employees.Queries.GetEmployeesByDepartment
{
    public class GetEmployeesByDepartmentQueryHadler(IEmployeeRepository employeeRepository, IUserService userService, IMapper mapper) : IRequestHandler<GetEmployeesByDepartmentQuery, IReadOnlyList<EmployeeDto>>
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;
        private readonly IUserService _userService = userService;
        private readonly IMapper _mapper = mapper;
        public async Task<IReadOnlyList<EmployeeDto>> Handle(GetEmployeesByDepartmentQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetByDepartmentAsync(request.Id);
            var users = await _userService.GetUsers();
            var usersDictionary = users.ToDictionary(x => x.Id);
            return employees
                .Where(e => usersDictionary.ContainsKey(e.IdentityUserId.ToString()))
                .Select(e =>
                {
                    var user = usersDictionary[e.IdentityUserId.ToString()];

                    return new EmployeeDto
                    {
                        Name = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        ClockNumber = e.ClockNumber,
                        HireDate = e.HireDate,
                        PhotoUrl = e.PhotoUrl,
                        Rfc = e.Rfc,
                        SocialNumber = e.SocialNumber
                    };
                })
                .ToList();
        }
    }
}