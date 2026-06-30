using ADigitalCompany.Application.Interfaces.Persistence;
using MediatR;

namespace ADigitalCompany.Application.Features.Employees.Commands.AssignManager
{
    public class AssignManagerCommandHandler(IDepartmentRepository departmentRepository) : IRequestHandler<AssignManagerCommand, Unit>
    {
        readonly IDepartmentRepository _departmentRepository = departmentRepository;
        public async Task<Unit> Handle(AssignManagerCommand request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetByCodeAsync(request.DeartmentCode);
            department?.ChangeManager(request.ManagerId);
            return Unit.Value;
        }
    }
}