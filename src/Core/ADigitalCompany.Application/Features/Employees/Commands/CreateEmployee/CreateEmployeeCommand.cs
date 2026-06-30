using ADigitalCompany.Domain;
using ADigitalCompany.Domain.Enums;
using MediatR;

namespace ADigitalCompany.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        // Identity
        public string Email { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;

        // Employee
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string ClockNumber { get; set; } = default!;
        public string Rfc { get; set; } = default!;
        public string SocialNumber { get; set; } = default!;
        public DateTime HireDate { get; set; }
        public int DepartmentId { get; set; }
        public JobPosition JobPosition { get; set; }
        public decimal Salary { get; set; }
    }
}