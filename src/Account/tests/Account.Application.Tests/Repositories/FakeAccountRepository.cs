using Account.Application.Interfaces;

namespace Account.Application.Tests.Repositories
{
    public class FakeAccountRepository : IAccountRepository
    {
        public List<Domain.Account> Accounts { get; } = new();

        public Task<Domain.Account> Add(Domain.Account account)
        {
            Accounts.Add(account);
            return Task.FromResult(account);
        }

        public Task<Domain.Account?> GetById(int id)
        {
            var account = Accounts.FirstOrDefault(a => a.Id == id);
            return Task.FromResult(account);
        }
    }
}
