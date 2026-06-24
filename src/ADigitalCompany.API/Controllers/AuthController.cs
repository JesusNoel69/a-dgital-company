using System.Security.Claims;
using ADigitalCompany.Application.Features.Auth.Commands.LoginUser;
using ADigitalCompany.Application.Features.Auth.Commands.RefreshToken;
using ADigitalCompany.Application.Features.Auth.Commands.RegisterUser;
using ADigitalCompany.Application.Features.Auth.Commands.RevokeToken;
using ADigitalCompany.Application.Features.Auth.Queries.GetCurrentUser;
using ADigitalCompany.Application.Interfaces.Identity;
using ADigitalCompany.Application.Models.Identity;
using ADigitalCompany.Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ADigitalCompany.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IMediator mediator, IUserService  userService) : ControllerBase
    {
        private readonly IMediator _mediator = mediator; 
        private readonly IUserService _userService = userService; 
        [HttpPost("login")] 
        public async Task<ActionResult<AuthResponse>> Login( [FromBody] AuthRequest request) 
        { 
            var response = await _mediator.Send( new LoginUserCommand
            {
                Email=request.Email,
                Password=request.Password,
            });
            return Ok(response); 
        } 
        [HttpPost("refresh")] 
        public async Task<ActionResult<AuthResponse>> Refresh( [FromBody] RefreshTokenCommand command) 
        { 
            return Ok(await _mediator.Send(command)); 
        } 
        [HttpPost("revoke")] 
        public async Task<IActionResult> Revoke( [FromBody] RevokeTokenCommand command) 
        {
            await _mediator.Send(command);
            return NoContent(); 
        }
        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register( [FromBody] RegisterUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        //Endpoints for test
        [Authorize]
        [HttpGet("me")]
        public async Task<ActionResult<User>> Me()
        {
            return Ok(await _mediator.Send(
                new GetCurrentUserQuery()));
        }
        [Authorize(Roles = Roles.Administrator)]
        [HttpGet("admin")]
        public IActionResult AdminOnly()
        {
            return Ok("You are an administrator");
        }
        [Authorize(Roles = Roles.Employee)]
        [HttpGet("employee")]
        public IActionResult EmployeeOnly()
        {
            return Ok("You are an employee");
        }
    }
}