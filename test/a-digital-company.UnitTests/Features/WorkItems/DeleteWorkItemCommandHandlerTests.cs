using a_digital_company.Application.Exceptions;
using a_digital_company.Application.Features.WorkItems.Commands.DeleteWorkItem;
using a_digital_company.Application.Interfaces.Logging;
using a_digital_company.Application.Interfaces.Persistence;
using a_digital_company.Domain;
using a_digital_company.UnitTests.Common.Mocks;
using Moq;
using Xunit;

namespace a_digital_company.UnitTests.Features.WorkItems
{
    public class DeleteWorkItemCommandHandlerTests
    {  
        private readonly Mock<IWorkItemRepository> _repositoryMock;
        private readonly Mock<IAppLogger<DeleteWorkItemCommandHandler>> _loggerMock;
        private readonly DeleteWorkItemCommandHandler _handler;
        public DeleteWorkItemCommandHandlerTests()
        {
            _repositoryMock = new Mock<IWorkItemRepository>();
            _loggerMock = new Mock<IAppLogger<DeleteWorkItemCommandHandler>>();
            _handler = new DeleteWorkItemCommandHandler(_repositoryMock.Object, _loggerMock.Object);
        }
       [Fact]
        public async Task Should_ThrowNotFound_WhenDeletingMissingWorkItem()
        {
            // Arrange
            _repositoryMock
                .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((WorkItem?)null);

            var command = new DeleteWorkItemCommand
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
        public async Task Should_Delete_WorkItem()
        {
            // Arrange
            var workItem = WorkItemMockData.GetWorkItem(null);
            
            _repositoryMock
                .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(workItem);

            var command = new DeleteWorkItemCommand
            {
                Id = 1
            };

            // Act
            await _handler.Handle(
                command,
                CancellationToken.None);

            // Assert
            _repositoryMock.Verify(
                x => x.DeleteAsync(workItem),
                Times.Once);
        }
    }
}