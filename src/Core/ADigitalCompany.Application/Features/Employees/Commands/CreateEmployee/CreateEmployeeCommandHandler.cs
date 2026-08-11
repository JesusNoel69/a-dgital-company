using System.Transactions;
using ADigitalCompany.Application.Exceptions;
using ADigitalCompany.Application.Interfaces.Identity;
using ADigitalCompany.Application.Interfaces.Persistence;
using ADigitalCompany.Application.Models.Identity;
using ADigitalCompany.Domain;
using MediatR;

namespace ADigitalCompany.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository, IUserService userService) : IRequestHandler<CreateEmployeeCommand, int>
    {
        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (await employeeRepository.ExistsEmployeeNumberAsync(request.ClockNumber))
                throw new BadRequestException("Employee number already exists.");

            var departmentExists =
                await departmentRepository.ExistsByIdAsync(request.DepartmentId);

            if (!departmentExists){
                throw new NotFoundException(
                    nameof(Department),
                    request.DepartmentId);
            }
            var user = await userService.CreateUser(new CreateUserRequest
            {
                Email = request.Email,
                //UserName = request.UserName,
                Password = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName
            });
            var employee = new Employee(
                user.Id,
                request.ClockNumber,
                request.Rfc,
                request.SocialNumber,
                request.HireDate,
                request.JobPosition,
                request.DepartmentId,
                request.Salary);

            await employeeRepository.CreateAsync(employee);

            return employee.Id;
        }
    }
}