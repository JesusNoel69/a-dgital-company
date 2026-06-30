using ADigitalCompany.Application.Exceptions;
using ADigitalCompany.Application.Interfaces.Persistence;
using ADigitalCompany.Domain;
using MediatR;

namespace ADigitalCompany.Application.Features.Departments.Commands.ChangeLocation
{
    public class ChangeLocationCommandHandler(IDepartmentRepository departmentRepository) : IRequestHandler<ChangeLocationCommand, Unit>
    {
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;
        public async Task<Unit> Handle(ChangeLocationCommand request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetByIdAsync(request.Id);
            if (department == null)
            {
                throw new NotFoundException(nameof(Department), request.Id);
            }
            department.ChangeLocation(request.Location);
            return Unit.Value;
        }
    }
}