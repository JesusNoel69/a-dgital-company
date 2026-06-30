using ADigitalCompany.Application.Models.Department;
using MediatR;

namespace ADigitalCompany.Application.Features.Departments.Queries.GetDepartments
{
    public class GetDepartmentsQuery() : IRequest<IReadOnlyList<DepartmentDto>>{}
}