using ADigitalCompany.Application.Interfaces.Persistence;
using ADigitalCompany.Domain;
using ADigitalCompany.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ADigitalCompany.Persistence.Repositories
{
    public class EmployeeRepository(ApplicationDbContext context) : GenericRepository<Employee>(context), IEmployeeRepository
    {
        public async Task<bool> ExistsEmployeeNumberAsync(string employeeNumber)
        {
            return await _context.Employees.AsNoTracking().AnyAsync(x=>x.ClockNumber==employeeNumber);
        }

        public async Task<List<Employee>> GetByDepartmentAsync(int departmentId)
        {
            return await _context.Employees.AsNoTracking().Where(x=>x.Department.Id==departmentId).ToListAsync();
        }

        public async Task<Employee?> GetByEmployeeNumberAsync(string employeeNumber)
        {
            return await _context.Employees.AsNoTracking().FirstOrDefaultAsync(x=> x.ClockNumber==employeeNumber);
        }

        public async Task<List<Employee>> GetByFieldAsync(string field)
        {
            return await _context.Employees.Where(x=> 
                    EF.Functions.Like(x.ClockNumber, $"%{field}%") ||
                    EF.Functions.Like(x.JobPosition, $"%{field}%") ||
                    EF.Functions.Like(x.SocialNumber, $"%{field}%") ||
                    EF.Functions.Like(x.Rfc, $"%{field}%"))
                .ToListAsync();
        }

        public async Task<Employee?> GetByIdentityUserIdAsync(string identityUserId)
        {
            return await _context.Employees.AsNoTracking().FirstOrDefaultAsync(x=>x.IdentityUserId==identityUserId);
        }

        public async Task<List<Employee>> GetByIdentityUserIdsAsync(List<string> Ids)
        {
            return await _context.Employees.Where(x=>Ids.Contains(x.IdentityUserId)).ToListAsync();
        }

        public async Task<List<Employee>> GetEmployeesByRangeAsync(int start, int end)
        {
            int valuesToTake = end-start;
            return await _context.Employees.AsNoTracking()
                .Skip(start)
                .Take(valuesToTake)
                .ToListAsync();
        }

        public async Task<List<Employee>> GetManagersAsync()
        {
            return await _context.Departments
                .AsNoTracking()
                .Join(
                    _context.Employees.AsNoTracking(), 
                    department => department.ResponsibleId,
                    employee => employee.IdentityUserId,
                    (department, employee)=> employee)
                .Distinct()
                .ToListAsync();
        }
        public async Task<bool> HasEmployeesAsync(int departmentId)
        {
            return await _context.Employees.AnyAsync(x=>x.Department.Id==departmentId);
        }
    }
}