using ADigitalCompany.Application.Exceptions;
using ADigitalCompany.Application.Interfaces.Persistence;
using ADigitalCompany.Domain;
using MediatR;

namespace ADigitalCompany.Application.Features.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommandHandler(IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository) : IRequestHandler<DeleteDepartmentCommand, Unit>
    {
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;
        public async Task<Unit> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetByIdAsync(request.Id);

            if (department is null)
            {
                throw new NotFoundException(nameof(Department), request.Id);
            }
            if (await _employeeRepository.HasEmployeesAsync(request.Id))
            {
                throw new BadRequestException(
                    "The department has assigned employees.");
            }
            await _departmentRepository.DeleteAsync(department);

            return Unit.Value;
        }
    }
}