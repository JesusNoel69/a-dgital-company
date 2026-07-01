using ADigitalCompany.Application.Features.Employees.Queries.GetEmployeesByDepartment;
using ADigitalCompany.Application.Models.Employee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ADigitalCompany.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        /*
        GET    /api/departments

        GET    /api/departments/{id}

        GET    /api/departments/{id}/employees

        POST   /api/departments

        PUT    /api/departments/{id}

        DELETE /api/departments/{id}
        */
        [HttpGet("{id:int}/employees")]
        public async Task<ActionResult<IReadOnlyList<EmployeeDto>>> GetEmployees(int id)
        {
            return Ok(await _mediator.Send(new GetEmployeesByDepartmentQuery(id)));
        }
    }
}