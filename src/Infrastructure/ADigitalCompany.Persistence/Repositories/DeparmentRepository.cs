using ADigitalCompany.Application.Interfaces.Persistence;
using ADigitalCompany.Domain;
using ADigitalCompany.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ADigitalCompany.Persistence.Repositories
{
    public class DeparmentRepository(ApplicationDbContext context) : GenericRepository<Department>(context), IDepartmentRepository
    {
        public async Task<bool> ExistsByCodeAsync(string code)
        {
            return await _context.Departments.AnyAsync( department => department.Code == code);
        }
        public async Task<Department?> GetByCodeAsync(string code)
        {
            return await _context.Departments.FirstOrDefaultAsync( department => department.Code == code);
        }
        public async Task<List<Department>> GetDepartmentsWithoutManagerAsync()
        {
            return await _context.Departments.Where( department => department.ResponsibleId == null).ToListAsync();
        }
    }
}