namespace Transfer.Api.Models
{
    public class TransferResponse
    {
        public int Id { get; set; }
        public int SourceAccountId { get; set; }
        public int TargetAccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
