using ADigitalCompany.Application.Models;
using MediatR;

namespace ADigitalCompany.Application.Features.Empoyees.Queries.GetEmployeById
{
    public record GetEmployeeByIdQuery(int Id) : IRequest<EmployeeDto>;
}