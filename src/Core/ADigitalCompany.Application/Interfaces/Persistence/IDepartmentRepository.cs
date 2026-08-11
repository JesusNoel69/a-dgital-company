using ADigitalCompany.Domain;

namespace ADigitalCompany.Application.Interfaces.Persistence
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Task<Department?> GetByCodeAsync(string code);
        Task<bool> ExistsByCodeAsync(string code);
        Task<bool> ExistsByIdAsync(int id);
        Task<List<Department>> GetDepartmentsWithoutManagerAsync();
    }
}