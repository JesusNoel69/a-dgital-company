using ADigitalCompany.Application.Features.Employees.Commands.CreateEmployee;
using ADigitalCompany.Application.Features.Employees.Commands.DeleteEmployee;
using ADigitalCompany.Application.Features.Employees.Commands.UpdateEmployee;
using ADigitalCompany.Application.Features.Employees.Queries.GetEmployeById;
using ADigitalCompany.Application.Features.Employees.Queries.GetEmployees;
using ADigitalCompany.Application.Features.Employees.Queries.GetEmployeesByDepartment;
using ADigitalCompany.Application.Features.Employees.Queries.GetManagers;
using ADigitalCompany.Application.Models.Employee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ADigitalCompany.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<EmployeeDto>>> GetAll()
        {
            return Ok(await _mediator.Send(new GetEmployeesQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmployeeDto>> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetEmployeeByIdQuery(id)));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateEmployeeCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEmployeeCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteEmployeeCommand { Id = id });

            return NoContent();
        }

        [HttpGet("managers")]
        public async Task<ActionResult<IReadOnlyList<EmployeeDto>>> GetManagers()
        {
            return Ok(await _mediator.Send(new GetManagersQuery()));
        }
    }
}