using ADigitalCompany.Application.Models;
using MediatR;

namespace ADigitalCompany.Application.Features.Employees.Queries.GetEmployees
{
    public record GetEmployeesQuery() : IRequest<IReadOnlyList<EmployeeDto>>;
}