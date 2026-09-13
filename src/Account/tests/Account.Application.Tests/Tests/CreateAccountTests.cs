using Account.Application.Tests.Repositories;
using Account.Domain.Enums;

namespace Account.Application.Tests.Tests
{
    public class CreateAccountTests
    {
        [Fact]
        public async Task Execute_WithValidData_ShouldCreateAccount()
        {
            // Arrange
            var repository = new FakeAccountRepository();
            var useCase = new CreateAccount(repository);

            // Act
            Domain.Account account = await useCase.Execute(1, 100);

            // Assert
            Assert.NotNull(account);
            Assert.Equal(1, account.CustomerId);
            Assert.Equal(100, account.Balance);
            Assert.Equal(AccountType.Current, account.AccountType);

            Assert.Single(repository.Accounts);
            Assert.Same(account, repository.Accounts[0]);
        }
    }
}
