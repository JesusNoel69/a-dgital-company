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

        public async Task<Employee?> GetByIdentityUserIdAsync(string identityUserId)
        {
            return await _context.Employees.AsNoTracking().FirstOrDefaultAsync(x=>x.IdentityUserId==identityUserId);
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
    }
}