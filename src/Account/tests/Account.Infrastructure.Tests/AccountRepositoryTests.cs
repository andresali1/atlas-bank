using Account.Infrastructure.Persistence;
using Account.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Account.Infrastructure.Tests
{
    public class AccountRepositoryTests
    {
        [Fact]
        public async Task Add_ShouldPersistAccount()
        {
            // Arrange
            var connectionString =
                "Host=localhost;Port=5434;Database=atlas_account;Username=account;Password=account";

            var options = new DbContextOptionsBuilder<AccountDbContext>()
                .UseNpgsql(connectionString)
                .Options;

            await using var context = new AccountDbContext(options);

            var repository = new AccountRepository(context);

            var account = Domain.Account.CreateCurrentAccount(1, 100);

            // Act
            Domain.Account createdAccount = await repository.Add(account);

            // Assert
            Assert.NotEqual(0, createdAccount.Id);

            Domain.Account? accountInDatabase =
                await repository.GetById(createdAccount.Id);

            Assert.NotNull(accountInDatabase);
            Assert.Equal(createdAccount.CustomerId, accountInDatabase.CustomerId);
            Assert.Equal(createdAccount.Balance, accountInDatabase.Balance);
            Assert.Equal(createdAccount.AccountType, accountInDatabase.AccountType);
            Assert.Equal(createdAccount.AccountStatus, accountInDatabase.AccountStatus);

            // Cleanup
            context.Accounts.Remove(accountInDatabase);
            await context.SaveChangesAsync();
        }
    }
}
