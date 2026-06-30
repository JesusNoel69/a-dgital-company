using ADigitalCompany.Application.Interfaces.Persistence;
using MediatR;

namespace ADigitalCompany.Application.Features.Employees.Commands.ChangeDepartment
{
    public class ChangeDepartmentCommandHandler(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository) : IRequestHandler<ChangeDepartmentCommand, Unit>
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;

        public async Task<Unit> Handle(ChangeDepartmentCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.EmployeeId);
            var newDepartment = await _departmentRepository.GetByIdAsync(request.NewDepartmentId);
            if(employee != null && newDepartment != null)
            {
                employee.ChangeDepartment(newDepartment);                
            }
            return Unit.Value;
        }
    }
}