using ADigitalCompany.Application.Models.Employee;
using MediatR;

namespace ADigitalCompany.Application.Features.Employees.Queries.GetEmployeesByRange
{
    public record GetEmployeesByRangeQuery(int Start, int End) : IRequest<IReadOnlyList<EmployeeDto>>;
}