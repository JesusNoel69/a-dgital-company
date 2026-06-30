using MediatR;

namespace ADigitalCompany.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommand : IRequest<int>
    {
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? ResponsibleId { get; set; }
    }
}