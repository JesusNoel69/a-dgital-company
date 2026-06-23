using a-digital-company.Application.Interfaces.Identity;
using a-digital-company.Domain;
using a-digital-company.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace a-digital-company.Persistence.Context
{
    public class ApplicationDbContext(IUserService userService, DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        private readonly IUserService _userService = userService;
        public DbSet<WorkItem> WorkItem { get; set; }
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