namespace Customer.Contracts.Interfaces
{
    public interface ICustomerRepository
    {
        Task<bool> ExistsByEmail(string email);
    }
}
