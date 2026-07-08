using ADigitalCompany.Application.Features.Departments.Commands.CreateDepartment;
using ADigitalCompany.Application.Features.Departments.Commands.DeleteDepartment;
using ADigitalCompany.Application.Features.Departments.Commands.UpdateDepartment;
using ADigitalCompany.Application.Features.Departments.Queries.GetDepartmentById;
using ADigitalCompany.Application.Features.Departments.Queries.GetDepartments;
using ADigitalCompany.Application.Features.Employees.Queries.GetEmployeesByDepartment;
using ADigitalCompany.Application.Models.Department;
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

        [HttpGet("{id:int}/employees")]
        public async Task<ActionResult<IReadOnlyList<EmployeeDto>>> GetEmployees(int id)
        {
            return Ok(await _mediator.Send(new GetEmployeesByDepartmentQuery(id)));
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DepartmentDto>>> GetAll()
        {
            return Ok(await _mediator.Send(new GetDepartmentsQuery()));
        }

        [HttpGet("{id:int}/departments")]
        public async Task<ActionResult<DepartmentDto>> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetDepartmentByIdQuery(id)));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateDepartmentCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateDepartmentCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteDepartmentCommand { Id = id });

            return NoContent();
        }
    }
}