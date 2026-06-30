using MediatR;

namespace ADigitalCompany.Application.Features.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}