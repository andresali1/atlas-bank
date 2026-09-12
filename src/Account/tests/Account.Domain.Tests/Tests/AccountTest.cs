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
        [Fact]
        public void Block_NonBlockedAccount_ShouldBecomeBlocked()
        {
            // Arrange
            Account account = Account.CreateCurrentAccount(1, 100);

            // Act
            account.Block();

            // Assert
            Assert.Equal(AccountStatus.Blocked, account.AccountStatus);
        }
        [Fact]
        public void Unblock_BlockedAccount_ShouldBecomeActive()
        {
            // Arrange
            Account account = Account.CreateCurrentAccount(1, 100);
            account.Block();

            // Act
            account.Unblock();

            // Assert
            Assert.Equal(AccountStatus.Active, account.AccountStatus);
        }
        [Fact]
        public void Deposit_ToBlockedAccount_ShouldNotChangeBalance()
        {
            // Arrange
            Account account = Account.CreateCurrentAccount(1, 100);
            account.Block();

            // Act & Assert
            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(
                    () => account.Deposit(50));

            Assert.Equal("Blocked account can't deposit", exception.Message);
        }
        [Fact]
        public void Deposit_WithInvalidAmount_ShouldNotChangeBalance()
        {
            // Arrange
            Account account = Account.CreateCurrentAccount(1, 100);

            // Act & Assert
            ArgumentException exception =
                Assert.Throws<ArgumentException>(
                    () => account.Deposit(-10));

            Assert.Equal("Amount to deposit must be greater than 0", exception.Message);
        }
        [Fact]
        public void Deposit_WithValidAmount_ShouldIncreaseBalance()
        {
            // Arrange
            Account account = Account.CreateCurrentAccount(1, 100);

            // Act
            account.Deposit(50);

            // Assert
            Assert.Equal(150, account.Balance);
        }
        [Fact]
        public void Withdraw_FromBlockedAccount_ShouldNotWithdraw()
        {
            // Arrange
            Account account = Account.CreateCurrentAccount(1, 100);
            account.Block();

            // Act & Assert
            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(
                    () => account.Withdraw(50));

            Assert.Equal("Blocked account can't withdraw", exception.Message);
        }
        [Fact]
        public void Withdraw_WithInvalidAmount_ShouldNotWithdraw()
        {
            // Arrange
            Account account = Account.CreateCurrentAccount(1, 100);

            // Act & Assert
            ArgumentException exception =
                Assert.Throws<ArgumentException>(
                    () => account.Withdraw(-10));

            Assert.Equal("Amount to withdraw must be greater than 0", exception.Message);
        }
        [Fact]
        public void Withdraw_WithMoreThanBalance_ShouldNotWithdraw()
        {
            // Arrange
            Account account = Account.CreateCurrentAccount(1, 100);

            // Act & Assert
            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(
                    () => account.Withdraw(110));

            Assert.Equal("Insufficient funds", exception.Message);
        }
        [Fact]
        public void Withdraw_WithValidData_ShouldWithdraw()
        {
            // Arrange
            Account account = Account.CreateCurrentAccount(1, 100);

            // Act
            account.Withdraw(50);

            // Assert
            Assert.Equal(50, account.Balance);
        }
    }
}
