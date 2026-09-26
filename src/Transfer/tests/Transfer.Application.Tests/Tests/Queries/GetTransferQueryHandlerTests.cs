using Transfer.Application.Queries.GetTransfer;
using Transfer.Application.Tests.Repositories;

namespace Transfer.Application.Tests.Tests.Queries
{
    public class GetTransferQueryHandlerTests
    {
        [Fact]
        public async Task Handle_WithExistingTransfer_ShouldReturnTransfer()
        {
            // Arrange
            var repository = new FakeTransferRepository();

            var handler = new GetTransferQueryHandler(repository);

            var query = new GetTransferQuery
            {
                Id = 0,
            };

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(0, result.Amount);
        }
    }
}
