using Microsoft.EntityFrameworkCore;
using Transfer.Infrastructure.Persistence;
using Transfer.Infrastructure.Repositories;

namespace Transfer.Infrastructure.Tests.Repositories
{
    public class TransferRepositoryTests
    {
        [Fact]
        public async Task Add_ShouldPersistTransfer()
        {
            // Arrange
            var connectionString =
                "Server=localhost,1434;Database=atlas_transfer;User Id=sa;Password=TransferPassword123!;TrustServerCertificate=True";

            var options =
                new DbContextOptionsBuilder<TransferDbContext>()
                    .UseSqlServer(connectionString)
                    .Options;

            await using var context =
                new TransferDbContext(options);

            var repository =
                new TransferRepository(context);

            var transfer =
                Domain.Transfer.Create(1, 2, 100);

            // Act
            var createdTransfer =
                await repository.Add(transfer);

            // Assert
            Assert.NotEqual(0, createdTransfer.Id);

            var transferInDatabase =
                await repository.GetById(createdTransfer.Id);

            Assert.NotNull(transferInDatabase);
            Assert.Equal(
                createdTransfer.SourceAccountId,
                transferInDatabase.SourceAccountId);

            Assert.Equal(
                createdTransfer.TargetAccountId,
                transferInDatabase.TargetAccountId);

            Assert.Equal(
                createdTransfer.Amount,
                transferInDatabase.Amount);

            // Cleanup
            context.Transfers.Remove(transferInDatabase);
            await context.SaveChangesAsync();
        }
        [Fact]
        public async Task GetById_ShouldReturnTransfer()
        {
            // Arrange
            var connectionString =
                "Server=localhost,1434;Database=atlas_transfer;User Id=sa;Password=TransferPassword123!;TrustServerCertificate=True";

            var options =
                new DbContextOptionsBuilder<TransferDbContext>()
                    .UseSqlServer(connectionString)
                    .Options;

            await using var context = new TransferDbContext(options);

            var repository = new TransferRepository(context);

            var transfer = Domain.Transfer.Create(1, 2, 250);

            var createdTransfer = await repository.Add(transfer);

            // Act
            var result = await repository.GetById(createdTransfer.Id);

            // Assert
            Assert.NotNull(result);

            Assert.Equal(
                createdTransfer.Id,
                result.Id);

            Assert.Equal(
                createdTransfer.SourceAccountId,
                result.SourceAccountId);

            Assert.Equal(
                createdTransfer.TargetAccountId,
                result.TargetAccountId);

            Assert.Equal(
                createdTransfer.Amount,
                result.Amount);

            // Cleanup
            context.Transfers.Remove(result);
            await context.SaveChangesAsync();
        }
    }
}
