
using ADigitalCompany.Application.Models.Employee;
using MediatR;

namespace ADigitalCompany.Application.Features.Employees.Queries.GetEmployeesByField
{
    public record GetEmployeesByFieldQuery(string Field): IRequest<IReadOnlyList<EmployeeDto>>;
}