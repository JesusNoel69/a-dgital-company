using ADigitalCompany.Application.Constants;
namespace ADigitalCompany.Application.Models.Identity
{
    public class CreateUserRequest
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Role { get; set; } = Roles.Employee;
    }
}