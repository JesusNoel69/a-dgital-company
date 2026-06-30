using ADigitalCompany.Application.Models;
using ADigitalCompany.Application.Models.Employee;
using MediatR;

namespace ADigitalCompany.Application.Features.Employees.Queries.GetEmployees
{
    public record GetEmployeesQuery() : IRequest<IReadOnlyList<EmployeeDto>>;
}