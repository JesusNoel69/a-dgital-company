using ADigitalCompany.Application.Models.Employee;
using MediatR;

namespace ADigitalCompany.Application.Features.Employees.Queries.GetEmployeesByDepartment
{
    public record GetEmployeesByDepartmentQuery(int Id) : IRequest<IReadOnlyList<EmployeeDto>>;
}