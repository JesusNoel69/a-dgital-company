using ADigitalCompany.Domain;

namespace ADigitalCompany.Application.Interfaces.Persistence
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Task<Department?> GetByCodeAsync(string code);
        Task<bool> ExistsByCodeAsync(string code);
        Task<List<Department>> GetDepartmentsWithoutManagerAsync();
    }
}