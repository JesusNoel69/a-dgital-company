using ADigitalCompany.Application.Interfaces.Persistence;
using ADigitalCompany.Domain;
using ADigitalCompany.Domain.Enums;
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
            var pattern = $"%{field}%";

            JobPosition? jobPosition = null;

            if (Enum.TryParse<JobPosition>(field,true, out var parsedJobPosition))
            {
                jobPosition = parsedJobPosition;
            }

            return await _context.Set<Employee>()
                .Where(e =>
                    EF.Functions.Like(e.ClockNumber, pattern) ||
                    EF.Functions.Like(e.SocialNumber, pattern) ||
                    EF.Functions.Like(e.Rfc, pattern) ||
                    (jobPosition.HasValue &&
                    e.JobPosition == jobPosition.Value))
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