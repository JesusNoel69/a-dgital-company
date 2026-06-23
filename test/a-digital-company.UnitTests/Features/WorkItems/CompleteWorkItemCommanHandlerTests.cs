using a-digital-company.Application.Exceptions;
using a-digital-company.Application.Features.WorkItems.Commands.CompleteWorkItem;
using a-digital-company.Application.Interfaces.Logging;
using a-digital-company.Application.Interfaces.Persistence;
using a-digital-company.Domain;
using a-digital-company.Domain.Enums;
using a-digital-company.UnitTests.Common.Mocks;
using Moq;
using Xunit;

namespace a-digital-company.UnitTests.Features.WorkItems
{
    public class CompleteWorkItemCommandHandlerTests
    {
        private readonly Mock<IWorkItemRepository> _repositoryMock;
        private readonly Mock<IAppLogger<CompleteWorkItemCommandHandler>> _loggerMock;
        private readonly CompleteWorkItemCommandHandler _handler;

        public CompleteWorkItemCommandHandlerTests()
        {
            _repositoryMock = new Mock<IWorkItemRepository>();
            _loggerMock = new Mock<IAppLogger<CompleteWorkItemCommandHandler>>();

            _handler = new CompleteWorkItemCommandHandler(
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

            var command =  new CompleteWorkItemCommand
            {
                Id = 1
            };

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(
                () => _handler.Handle(
                    command,
                    CancellationToken.None));
        }

        [Fact]
        public async Task Should_Complete_WorkItem()
        {
            // Arrange
            var workItem = WorkItemMockData.GetWorkItem(null);

            _repositoryMock
                .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(workItem);

            var command =  new CompleteWorkItemCommand
            {
                Id = 1
            };

            // Act
            await _handler.Handle(
                command,
                CancellationToken.None);

            // Assert
            Assert.Equal(
                WorkItemStatus.Completed,
                workItem.Status);

            _repositoryMock.Verify(
                x => x.UpdateAsync(workItem),
                Times.Once);
        }
    }
}