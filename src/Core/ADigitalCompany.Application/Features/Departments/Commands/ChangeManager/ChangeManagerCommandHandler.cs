using ADigitalCompany.Application.Exceptions;
using ADigitalCompany.Application.Interfaces.Persistence;
using ADigitalCompany.Domain;
using MediatR;

namespace ADigitalCompany.Application.Features.Departments.Commands.ChangeManager
{
    public class ChangeManagerCommandHandler(IDepartmentRepository departmentRepository) : IRequestHandler<ChangeManagerCommand, Unit>
    {
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;
        public async Task<Unit> Handle(ChangeManagerCommand request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetByIdAsync(request.Id);
            if (department == null)
            {
                throw new NotFoundException(nameof(Department), request.Id);
            }
            department.ChangeManager(request.Manager);
            return Unit.Value;
        }
    }
}