namespace Customer.Contracts.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Entities.Customer> GetById(int id);
        Task<bool> ExistsByEmail(string email);
        Task<Entities.Customer> Add(Entities.Customer customer);
    }
}
