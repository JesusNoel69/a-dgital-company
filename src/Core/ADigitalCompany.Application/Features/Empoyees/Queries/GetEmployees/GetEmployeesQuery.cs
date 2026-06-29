using ADigitalCompany.Application.Models;
using MediatR;

namespace ADigitalCompany.Application.Features.Empoyees.Queries.GetEmployees
{
    public record GetEmployeesQuery() : IRequest<IReadOnlyList<EmployeeDto>>;
}