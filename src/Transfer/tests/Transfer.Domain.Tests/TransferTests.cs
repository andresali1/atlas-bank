namespace Transfer.Domain.Tests
{
    public class TransferTests
    {
        [Fact]
        public void Create_WithInvalidSourceAccount_ShouldThrow()
        {
            // Arrange
            int sourceAccountId = 0;
            int targetAccountId = 2;
            decimal amount = 100;

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                Transfer.Create(
                    sourceAccountId,
                    targetAccountId,
                    amount
                )
            );

            Assert.Equal("Invalid source account", exception.Message);
        }
        [Fact]
        public void Create_WithInvalidTargetAccount_ShouldThrow()
        {
            // Arrange
            int sourceAccountId = 1;
            int targetAccountId = 0;
            decimal amount = 100;

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                Transfer.Create(
                    sourceAccountId,
                    targetAccountId,
                    amount
                )
            );

            Assert.Equal("Invalid target account", exception.Message);
        }
        [Fact]
        public void Create_WithSameSourceAndTargetAccount_ShouldThrow()
        {
            // Arrange
            int sourceAccountId = 1;
            int targetAccountId = 1;
            decimal amount = 100;

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                Transfer.Create(
                    sourceAccountId,
                    targetAccountId,
                    amount
                )
            );

            Assert.Equal("Source and target accounts must be different", exception.Message);
        }
        [Fact]
        public void Create_WithInvalidAmount_ShouldThrow()
        {
            // Arrange
            int sourceAccountId = 1;
            int targetAccountId = 2;
            decimal amount = 0;

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() =>
                Transfer.Create(
                    sourceAccountId,
                    targetAccountId,
                    amount
                )
            );

            Assert.Equal("Transfer amount must be greater than 0", exception.Message);
        }
        [Fact]
        public void Create_WithValidData_ShouldCreate()
        {
            // Arrange
            int sourceAccountId = 1;
            int targetAccountId = 2;
            decimal amount = 100;

            // Act
            var transfer = Transfer.Create(
                sourceAccountId,
                targetAccountId,
                amount
            );

            // Assert
            Assert.NotNull(transfer);
            Assert.Equal(transfer.SourceAccountId, sourceAccountId);
            Assert.Equal(transfer.TargetAccountId, targetAccountId);
            Assert.Equal(transfer.Amount, amount);
        }
    }
}
