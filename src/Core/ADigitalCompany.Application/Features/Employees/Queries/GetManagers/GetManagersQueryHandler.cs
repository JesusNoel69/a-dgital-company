using ADigitalCompany.Application.Interfaces.Identity;
using ADigitalCompany.Application.Interfaces.Persistence;
using ADigitalCompany.Application.Models.Employee;
using MediatR;

namespace ADigitalCompany.Application.Features.Employees.Queries.GetManagers
{
    public class GetManagersQueryHandler(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository, IUserService userService) : IRequestHandler<GetManagersQuery, IReadOnlyList<EmployeeDto>>
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;
        private readonly IUserService _userService = userService;
        public async Task<IReadOnlyList<EmployeeDto>> Handle(GetManagersQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetManagersAsync();
            var users = await _userService.GetUsers();

            var usersDictionary = users.ToDictionary(x => x.Id);

            var result = new List<EmployeeDto>();

            foreach (var employee in employees)
            {
                if (!usersDictionary.TryGetValue(employee.IdentityUserId.ToString(), out var user))
                    continue;

                result.Add(new EmployeeDto
                {
                    Name = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,

                    ClockNumber = employee.ClockNumber,
                    HireDate = employee.HireDate,
                    PhotoUrl = employee.PhotoUrl,
                    Rfc = employee.Rfc,
                    SocialNumber = employee.SocialNumber
                });
            }
            return result;
        }
    }
}