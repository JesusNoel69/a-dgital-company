using ADigitalCompany.Application.Interfaces.Identity;
using ADigitalCompany.Domain;
using ADigitalCompany.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace ADigitalCompany.Persistence.Context
{
    public class ApplicationDbContext(IUserService userService, DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        private readonly IUserService _userService = userService;
        public DbSet<WorkItem> WorkItem { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.UtcNow;
                entry.Entity.ModifiedBy = _userService.UserId;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.UtcNow;
                    entry.Entity.CreatedBy = _userService.UserId;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}