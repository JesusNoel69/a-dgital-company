using MediatR;

namespace ADigitalCompany.Application.Features.Employees.Commands.ChangeDepartment
{
    public class ChangeDepartmentCommand : IRequest<Unit>
    {
        public int EmployeeId { get; set; }
        public int NewDepartmentId { get; set; }
    }
}