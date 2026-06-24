using ADigitalCompany.Application.Exceptions;
using ADigitalCompany.Application.Features.WorkItems.Commands.ChangePriority;
using ADigitalCompany.Application.Interfaces.Logging;
using ADigitalCompany.Application.Interfaces.Persistence;
using ADigitalCompany.Domain;
using ADigitalCompany.Domain.Enums;
using ADigitalCompany.UnitTests.Common.Mocks;
using Moq;
using Xunit;

namespace ADigitalCompany.UnitTests.Features.WorkItems
{
    public class ChangePriorityCommandHandlerTests
    {
        private readonly Mock<IWorkItemRepository> _repositoryMock;
        private readonly Mock<IAppLogger<ChangePriorityCommandHandler>> _loggerMock;
        private readonly ChangePriorityCommandHandler _handler;

        public ChangePriorityCommandHandlerTests()
        {
            _repositoryMock = new Mock<IWorkItemRepository>();
            _loggerMock = new Mock<IAppLogger<ChangePriorityCommandHandler>>();

            _handler = new ChangePriorityCommandHandler(
                _repositoryMock.Object,
                _loggerMock.Object);
        }

        [Fact]
        public async Task Should_ThrowNotFound_WhenWorkItemDoesNotExist()
        {
            // Arrange
            _repositoryMock
                .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((WorkItem?)null);

            var command = new ChangePriorityCommand
            {
                Id = 1,
                Priority = WorkItemPriority.High
            };

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(
                () => _handler.Handle(
                    command,
                    CancellationToken.None));
        }

        [Fact]
        public async Task Should_Change_WorkItem_Priority()
        {
            // Arrange
            var workItem = WorkItemMockData.GetWorkItem(WorkItemPriority.Low);

            _repositoryMock
                .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(workItem);

            var command = new ChangePriorityCommand
            {
                Id = 1,
                Priority = WorkItemPriority.High
            };

            // Act
            await _handler.Handle(
                command,
                CancellationToken.None);

            // Assert
            Assert.Equal(
                WorkItemPriority.High,
                workItem.Priority);

            _repositoryMock.Verify(
                x => x.UpdateAsync(workItem),
                Times.Once);
        }
    }
}