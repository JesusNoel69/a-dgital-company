using ADigitalCompany.Application.Models.Department;
using MediatR;

namespace ADigitalCompany.Application.Features.Departments.Queries.GetDepartmentById
{
    public record GetDepartmentByIdQuery(int Id) : IRequest<DepartmentDto>{}
}