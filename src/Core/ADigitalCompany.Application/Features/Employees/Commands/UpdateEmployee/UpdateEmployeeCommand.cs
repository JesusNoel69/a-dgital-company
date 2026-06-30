using ADigitalCompany.Application.Models.Employee;
using ADigitalCompany.Domain.Enums;
using MediatR;

namespace ADigitalCompany.Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest<EmployeeDto>
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string ClockNumber { get; set; } = default!;
        public string Rfc { get; set; } = default!;
        public string SocialNumber { get; set; } = default!;
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public JobPosition JobPosition { get; set; }
    }
}