using MediatR;

namespace ADigitalCompany.Application.Features.Employees.Queries.GetEmployeesNumber
{
    public record GetEmployeesNumberQuery() : IRequest<int>;
}