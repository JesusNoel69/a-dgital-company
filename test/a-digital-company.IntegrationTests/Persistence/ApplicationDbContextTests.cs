using a-digital-company.Application.Interfaces.Identity;
using a-digital-company.Domain;
using a-digital-company.Domain.Enums;
using a-digital-company.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace a-digital-company.IntegrationTests.Persistence
{
    public class ApplicationDbContextTests
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly ApplicationDbContext _context;
        public ApplicationDbContextTests()
        {
            _userServiceMock = new Mock<IUserService>();

            _userServiceMock
                .Setup(x => x.UserId)
                .Returns("user-123");

            var options =
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

            _context = new ApplicationDbContext(
                _userServiceMock.Object,
                options);
        }
        [Fact]
        public async Task SaveChanges_Should_Set_DateCreated()
        {
            // Arrange
            var workItem = new WorkItem(
                "Task",
                "Description",
                "user-123",
                WorkItemPriority.Medium);

            // Act
            await _context.WorkItem.AddAsync(workItem);

            await _context.SaveChangesAsync();

            // Assert
            Assert.NotEqual(
                default,
                workItem.DateCreated);
        }
        [Fact]
        public async Task SaveChanges_Should_Set_DateModified()
        {
            // Arrange
            var workItem = new WorkItem(
                "Task",
                "Description",
                "user-123",
                WorkItemPriority.Medium);

            await _context.WorkItem.AddAsync(workItem);

            await _context.SaveChangesAsync();

            // Act
            workItem.ChangePriority(
                WorkItemPriority.High);

            await _context.SaveChangesAsync();

            // Assert
            Assert.NotEqual(
                default,
                workItem.DateModified);
        }
        [Fact]
        public async Task SaveChanges_Should_Set_CreatedBy()
        {
            // Arrange
            var workItem = new WorkItem(
                "Task",
                "Description",
                "user-123",
                WorkItemPriority.Medium);

            // Act
            await _context.WorkItem.AddAsync(workItem);

            await _context.SaveChangesAsync();

            // Assert
            Assert.Equal(
                "user-123",
                workItem.CreatedBy);
        }
        [Fact]
        public async Task SaveChanges_Should_Set_ModifiedBy()
        {
            // Arrange
            var workItem = new WorkItem(
                "Task",
                "Description",
                "user-123",
                WorkItemPriority.Medium);

            await _context.WorkItem.AddAsync(workItem);

            await _context.SaveChangesAsync();

            // Act
            workItem.ChangePriority(
                WorkItemPriority.High);

            await _context.SaveChangesAsync();

            // Assert
            Assert.Equal(
                "user-123",
                workItem.ModifiedBy);
        }
    }
}