using Account.Domain.Enums;

namespace Account.Domain
{
    public class Account
    {
        public int Id { get; private set; }
        public int CustomerId { get; private set; }
        public decimal Balance { get; private set; }
        public AccountType AccountType { get; private set; }
        public AccountStatus AccountStatus { get; private set; }
        private Account(
            int customerId,
            decimal balance,
            AccountType accountType,
            AccountStatus accountStatus)
        {
            CustomerId = customerId;
            Balance = balance;
            AccountType = accountType;
            AccountStatus = accountStatus;
        }
        public static Account CreateCurrentAccount(int customerId, decimal balance)
        {
            if (customerId <= 0)
            {
                throw new ArgumentException("Invalid customer");
            }

            if (balance < 0)
            {
                throw new ArgumentException("Balance cannot be negative");
            }

            return new Account(customerId, balance, AccountType.Current, AccountStatus.Active);
        }
        public void Block()
        {
            this.AccountStatus = AccountStatus.Blocked;
        }
        public void Unblock()
        {
            this.AccountStatus = AccountStatus.Active;
        }
        public void Deposit(decimal amount)
        {
            if (this.AccountStatus == AccountStatus.Blocked)
            {
                throw new InvalidOperationException("Blocked account can't deposit");
            }

            if (amount <= 0)
            {
                throw new ArgumentException("Amount to deposit must be greater than 0");
            }

            Balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            if (this.AccountStatus == AccountStatus.Blocked)
            {
                throw new InvalidOperationException("Blocked account can't withdraw");
            }

            if (amount <= 0)
            {
                throw new ArgumentException("Amount to withdraw must be greater than 0");
            }

            if (amount > this.Balance)
            {
                throw new InvalidOperationException("Insufficient funds");
            }

            this.Balance -= amount;
        }
    }
}
