using ADigitalCompany.Application.Exceptions;
using ADigitalCompany.Application.Interfaces.Identity;
using ADigitalCompany.Application.Interfaces.Persistence;
using ADigitalCompany.Application.Models.Employee;
using ADigitalCompany.Application.Models.Identity;
using ADigitalCompany.Domain;
using MediatR;

namespace ADigitalCompany.Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository, IUserService userService) : IRequestHandler<UpdateEmployeeCommand, EmployeeDto>
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;
        private readonly IUserService _userService = userService;
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;
        public async Task<EmployeeDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id);
            if (employee is null)
                throw new NotFoundException(nameof(Employee), request.Id);

            await _userService.UpdateUser(new UpdateUserRequest
            {
                Id = employee.IdentityUserId,
                FirstName = request.FirstName,
                LastName = request.LastName
            });

            employee.ChangeClockNumber(request.ClockNumber);
            employee.ChangeRfc(request.Rfc);
            employee.ChangeSocialNumber(request.SocialNumber);
            employee.ChangeSalary(request.Salary);
            employee.ChangeJobPosition(request.JobPosition);

            var department = await _departmentRepository.GetByIdAsync(request.DepartmentId);

            employee.ChangeDepartment(department);

            await _employeeRepository.UpdateAsync(employee);

            return new EmployeeDto()
            {
                ClockNumber=request.ClockNumber,
                Email=request.Email,
                HireDate=employee.HireDate,
                LastName=request.LastName,
                Name=request.FirstName,
                PhotoUrl=employee.PhotoUrl,
                Rfc=request.Rfc,
                SocialNumber=request.SocialNumber
            };
        }
    }
}