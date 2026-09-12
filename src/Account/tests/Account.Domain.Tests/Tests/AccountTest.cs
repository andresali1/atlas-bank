using Account.Domain.Enums;

namespace Account.Domain.Tests.Tests
{
    public class AccountTest
    {
        [Fact]
        public void CreateAccount_WithInvalidCustomer_ShouldRejectCreate()
        {
            // Arrange
            int customerId = 0;
            decimal balance = 0;

            // Act & Assert
            ArgumentException exception =
                Assert.Throws<ArgumentException>(
                    () => Account.CreateCurrentAccount(customerId, balance));

            Assert.Equal("Invalid customer", exception.Message);
        }
        [Fact]
        public void CreateAccount_WithInvalidBalance_ShouldRejectCreate()
        {
            // Arrange
            int customerId = 1;
            decimal balance = -1;

            // Act & Assert
            ArgumentException exception =
                Assert.Throws<ArgumentException>(
                    () => Account.CreateCurrentAccount(customerId, balance));

            Assert.Equal("Balance cannot be negative", exception.Message);
        }
        [Fact]
        public void CreateAccount_WithValidData_ShouldCreate()
        {
            // Arrange
            int customerId = 1;
            decimal balance = 0;

            // Act
            Account account = Account.CreateCurrentAccount(customerId, balance);

            // Assert
            Assert.NotNull(account);
            Assert.Equal(customerId, account.CustomerId);
            Assert.Equal(AccountType.Current, account.AccountType);
            Assert.Equal(AccountStatus.Active, account.AccountStatus);
        }
    }
}
