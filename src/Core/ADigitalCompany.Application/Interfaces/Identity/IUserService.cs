using ADigitalCompany.Application.Models.Identity;
namespace ADigitalCompany.Application.Interfaces.Identity
{
    public interface IUserService
    {
        Task<List<User?>> GetUsers();
        Task<User> GetUser(string userId);
        public string UserId { get; }
        Task<User> UpdateUser(UpdateUserRequest request);
        Task DeleteUser(string userId);
        Task AssignRole(string userId, string role);
    }
}