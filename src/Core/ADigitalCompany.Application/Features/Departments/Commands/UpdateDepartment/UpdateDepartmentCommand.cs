using MediatR;

namespace ADigitalCompany.Application.Features.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string Code { get; set; } = default!;

        public string? Description { get; set; }

        public string? Location { get; set; }

        public string? ResponsibleId { get; set; }
    }
}
