using ADigitalCompany.Application.Models.Employee;
using MediatR;

namespace ADigitalCompany.Application.Features.Employees.Queries.GetManagers
{
    public record GetManagersQuery() : IRequest<IReadOnlyList<EmployeeDto>>{}
}