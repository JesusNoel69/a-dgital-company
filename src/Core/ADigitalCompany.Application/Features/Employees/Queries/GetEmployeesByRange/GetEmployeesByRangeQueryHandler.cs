using ADigitalCompany.Application.Interfaces.Identity;
using ADigitalCompany.Application.Interfaces.Persistence;
using ADigitalCompany.Application.Models.Employee;
using AutoMapper;
using MediatR;

namespace ADigitalCompany.Application.Features.Employees.Queries.GetEmployeesByRange
{
    public class GetEmployeesByRangeQueryHandler(IEmployeeRepository employeeRepository, IUserService _userService, IMapper _mapper) : IRequestHandler<GetEmployeesByRangeQuery, IReadOnlyList<EmployeeDto>>
    {
        private readonly IEmployeeRepository _employeeRepository=employeeRepository;
        public async Task<IReadOnlyList<EmployeeDto>> Handle(GetEmployeesByRangeQuery request, CancellationToken cancellationToken)
        {
                var employees = await _employeeRepository
                    .GetEmployeesByRangeAsync(request.Start, request.End);
            var users = await _userService.GetUsers();

            return employees.Join(
                users,
                emp => emp.IdentityUserId.ToString(),
                user => user.Id,
                (emp, user) => new EmployeeDto
                {
                    Name = user?.FirstName,
                    LastName = user.LastName,
                    HireDate = emp.HireDate,
                    Email = user?.Email??"",
                    PhotoUrl = emp.PhotoUrl,
                    Rfc = emp.Rfc,
                    SocialNumber = emp.SocialNumber,
                    ClockNumber = emp.ClockNumber
                })
                .ToList();
                //return _mapper.Map<List<EmployeeDto>>(employees);
        }
    }
}