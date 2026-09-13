using Account.Domain.Enums;

namespace Account.Api.Models
{
    public class CreateAccountResponse
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Balance { get; set; }
        public AccountType AccountType { get; set; }
        public AccountStatus AccountStatus { get; set; }
    }
}
