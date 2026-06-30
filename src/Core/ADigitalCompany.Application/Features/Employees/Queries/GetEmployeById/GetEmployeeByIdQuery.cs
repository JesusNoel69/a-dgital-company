using ADigitalCompany.Application.Models;
using MediatR;

namespace ADigitalCompany.Application.Features.Employees.Queries.GetEmployeById
{
    public record GetEmployeeByIdQuery(int Id) : IRequest<EmployeeDto>;
}