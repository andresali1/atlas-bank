namespace Transfer.Domain
{
    public class Transfer
    {
        public int Id { get; private set; }
        public int SourceAccountId { get; private set; }
        public int TargetAccountId { get; private set; }
        public decimal Amount { get; private set; }

        private Transfer(
            int sourceAccountId,
            int targetAccountId,
            decimal amount)
        {
            SourceAccountId = sourceAccountId;
            TargetAccountId = targetAccountId;
            Amount = amount;
        }

        public static Transfer Create(
            int sourceAccountId,
            int targetAccountId,
            decimal amount)
        {
            if (sourceAccountId <= 0)
                throw new ArgumentException("Invalid source account");

            if(targetAccountId <= 0)
                throw new ArgumentException("Invalid target account");

            if(sourceAccountId == targetAccountId)
                throw new ArgumentException("Source and target accounts must be different");

            if (amount <= 0)
                throw new ArgumentException("Transfer amount must be greater than 0");

            return new Transfer(
                sourceAccountId,
                targetAccountId,
                amount);
        }
    }
}
