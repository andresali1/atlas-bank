namespace Account.Application.Interfaces
{
    public interface IAccountRepository
    {
        Task<Domain.Account> Add(Domain.Account account);
        Task<Domain.Account?> GetById(int id);
    }
}
