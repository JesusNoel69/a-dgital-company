using ADigitalCompany.Application.Interfaces.Identity;
using ADigitalCompany.Application.Interfaces.Persistence;
using ADigitalCompany.Application.Models;
using MediatR;

namespace ADigitalCompany.Application.Features.Empoyees.Queries.GetEmployeById
{
    public class GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository, IUserService userService) : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;
        private readonly IUserService _userService = userService;

        public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id);
            var user = await _userService.GetUser(employee.IdentityUserId.ToString());

            return new EmployeeDto
                {
                    Name = user.FirstName,
                    LastName = user.LastName,
                    HireDate = employee.HireDate,
                    Email = user?.Email??"",
                    PhotoUrl = employee.PhotoUrl,
                    Rfc = employee.Rfc,
                    SocialNumber = employee.SocialNumber,
                    ClockNumber = employee.ClockNumber
                };
        }
    }
}