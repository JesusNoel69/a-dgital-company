using ADigitalCompany.Domain;

namespace ADigitalCompany.Application.Interfaces.Persistence
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<Employee?> GetByIdentityUserIdAsync(string identityUserId);
        Task<Employee?> GetByEmployeeNumberAsync(string employeeNumber);
        Task<bool> ExistsEmployeeNumberAsync(string employeeNumber);
        Task<List<Employee>> GetByDepartmentAsync(int departmentId);
        Task<List<Employee>> GetManagersAsync();
        Task<List<Employee>> GetEmployeesByRangeAsync(int start, int end);
        Task<bool> HasEmployeesAsync(int departmentId);
        Task<List<Employee>> GetByFieldAsync(string field);
        Task<List<Employee>> GetByIdentityUserIdsAsync(List<string> Ids);
    }
}