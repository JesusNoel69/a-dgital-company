using ADigitalCompany.Application.Exceptions;
using ADigitalCompany.Application.Interfaces.Persistence;
using ADigitalCompany.Domain;
using MediatR;

namespace ADigitalCompany.Application.Features.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandHandler(IDepartmentRepository departmentRepository) : IRequestHandler<UpdateDepartmentCommand, Unit>
    {
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;
        public async Task<Unit> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetByIdAsync(request.Id);

            if (department is null)
            {
                throw new NotFoundException(nameof(Department), request.Id);
            }
            department.ChangeName(request.Name);
            department.ChangeCode(request.Code);
            department.ChangeDescription(request.Description);
            department.ChangeLocation(request.Location);
            department.ChangeManager(request.ResponsibleId);

            await _departmentRepository.UpdateAsync(department);

            return Unit.Value;
        }
    }
}