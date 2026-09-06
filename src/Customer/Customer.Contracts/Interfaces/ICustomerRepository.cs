namespace Customer.Contracts.Interfaces
{
    public interface ICustomerRepository
    {
        Task<bool> ExistsByEmail(string email);
        Task<Entities.Customer> Add(Entities.Customer customer);
    }
}
