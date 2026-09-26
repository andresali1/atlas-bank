using Transfer.Application.Commands.CreateTransfer;
using Transfer.Application.Tests.Repositories;

namespace Transfer.Application.Tests.Tests.Commands
{
    public class CreateTransferCommandHandlerTests
    {
        [Fact]
        public async Task Handle_WithValidData_ShouldCreateTransfer()
        {
            // Arrange
            var repository = new FakeTransferRepository();

            var handler = new CreateTransferCommandHandler(repository);

            var command = new CreateTransferCommand
            {
                SourceAccountId = 1,
                TargetAccountId = 2,
                Amount = 100
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(command.SourceAccountId, result.SourceAccountId);
            Assert.Equal(command.TargetAccountId, result.TargetAccountId);
            Assert.Equal(command.Amount, result.Amount);
        }
    }
}
