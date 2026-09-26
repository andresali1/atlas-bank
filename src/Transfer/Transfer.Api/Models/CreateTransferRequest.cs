namespace Transfer.Api.Models
{
    public class CreateTransferRequest
    {
        public int SourceAccountId { get; set; }
        public int TargetAccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
