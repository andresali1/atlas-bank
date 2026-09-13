using Account.Application.Interfaces;

namespace Account.Application
{
    public class CreateAccount
    {
        private readonly IAccountRepository repository;

        public CreateAccount(IAccountRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Domain.Account> Execute(int customerId, decimal balance)
        {
            Domain.Account account =
                Domain.Account.CreateCurrentAccount(customerId, balance);

            return await repository.Add(account);
        }
    }
}
