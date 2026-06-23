using a-digital-company.Application.Interfaces.Persistence;
using a-digital-company.Domain;
using a-digital-company.Domain.Enums;
using a-digital-company.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace a-digital-company.Persistence.Repositories
{
    public class WorkItemRepository(ApplicationDbContext context) : GenericRepository<WorkItem>(context), IWorkItemRepository
    {
        public async Task Addworkitems(List<WorkItem> workItems)
        {
            await _context.WorkItem.AddRangeAsync(workItems);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> WorkItemExists(string userId, string title)
        {
            return await _context.WorkItem.AnyAsync(x => x.UserId == userId && x.Title == title);
        }
        public async Task<List<WorkItem>> GetByUserId(string userId)
        {
            return await _context.WorkItem.Where(x=> x.UserId == userId).ToListAsync();
        }
        public async Task<WorkItem?> GetByIdAndUserId(int id, string userId)
        {
            return await _context.WorkItem.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
        }
        public async Task<List<WorkItem>> GetPendingByUserId(string userId)
        {
            return await _context.WorkItem.Where(x=> x.UserId == userId && x.Status == WorkItemStatus.Pending).ToListAsync();
        }
        public async Task<List<WorkItem>> GetOverdueByUserId(string userId)
        {
            return await _context.WorkItem.Where(x=> x.UserId == userId && x.DueDate < DateTime.UtcNow && x.Status != WorkItemStatus.Completed).ToListAsync();
        }
        public async Task<List<WorkItem>> GetWorkItemsWithDetails()
        {
            return await _context.WorkItem.ToListAsync();
        }
    }
}