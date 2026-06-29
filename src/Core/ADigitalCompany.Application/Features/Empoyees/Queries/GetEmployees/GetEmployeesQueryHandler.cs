using ADigitalCompany.Application.Interfaces.Identity;
using ADigitalCompany.Application.Interfaces.Persistence;
using ADigitalCompany.Application.Models;
using ADigitalCompany.Domain;
using AutoMapper;
using MediatR;

namespace ADigitalCompany.Application.Features.Empoyees.Queries.GetEmployees
{
    public class GetEmployeesQueryHandler(IEmployeeRepository employeeRepository, IUserService userService) : IRequestHandler<GetEmployeesQuery, IReadOnlyList<EmployeeDto>>
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;
        private readonly IUserService _userService = userService;
        public async Task<IReadOnlyList<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {

            var employees = await _employeeRepository.GetAsync();
            var users = await _userService.GetUsers();

            return employees.Join(
                users,
                emp => emp.IdentityUserId.ToString(),
                user => user.Id,
                (emp, user) => new EmployeeDto
                {
                    Name = emp.Name,
                    LastName = emp.LastName,
                    HireDate = emp.HireDate,
                    Email = user?.Email??"",
                    PhotoUrl = emp.PhotoUrl,
                    Rfc = emp.Rfc,
                    SocialNumber = emp.SocialNumber,
                    ClockNumber = emp.ClockNumber
                })
                .ToList();
        }
    }
}