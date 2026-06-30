using ADigitalCompany.Application.Interfaces.Identity;
using ADigitalCompany.Application.Interfaces.Persistence;
using MediatR;

namespace ADigitalCompany.Application.Features.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository,IUserService userService) : IRequestHandler<DeleteEmployeeCommand, Unit>
    {
        private readonly IUserService _userService = userService;
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;
        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var user = await _employeeRepository.GetByIdAsync(request.Id);
            if(user != null)
            {
                await _employeeRepository.DeleteAsync(user);
                await _userService.DeleteUser(user.IdentityUserId);                            
            }
            return Unit.Value;
        }
    }
}