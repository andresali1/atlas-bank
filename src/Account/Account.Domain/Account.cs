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
        public 
    }
}
