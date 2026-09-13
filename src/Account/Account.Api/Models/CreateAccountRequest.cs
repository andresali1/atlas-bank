namespace Account.Api.Models
{
    public class CreateAccountRequest
    {
        public int CustomerId { get; set; }
        public decimal InitialBalance { get; set; }
    }
}
