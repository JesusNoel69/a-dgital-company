using ADigitalCompany.Application.Exceptions;
using ADigitalCompany.Application.Interfaces.Persistence;
using ADigitalCompany.Domain;
using MediatR;

namespace ADigitalCompany.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandHandler(IDepartmentRepository departmentRepository) : IRequestHandler<CreateDepartmentCommand, int>
    {
        public async Task<int> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            if (await departmentRepository.ExistsByCodeAsync(request.Code))
            {
                throw new BadRequestException("Department code already exists.");
            }
            var department = new Department(
                request.Name,
                request.Code,
                request.Description,
                request.Location,
                request.ResponsibleId);
 
            await departmentRepository.CreateAsync(department);
 
            return department.Id;
        }
    }
}