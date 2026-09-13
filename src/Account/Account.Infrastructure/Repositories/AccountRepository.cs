using Account.Application.Interfaces;
using Account.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Account.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountDbContext context;

        public AccountRepository(AccountDbContext context)
        {
            this.context = context;
        }

        public async Task<Domain.Account> Add(Domain.Account account)
        {
            await context.Accounts.AddAsync(account);
            await context.SaveChangesAsync();

            return account;
        }

        public async Task<Domain.Account?> GetById(int id)
        {
            return await context.Accounts
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
