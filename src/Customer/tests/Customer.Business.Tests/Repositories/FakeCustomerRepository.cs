using Customer.Contracts.Interfaces;

namespace Customer.Business.Tests.Repositories
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        private readonly List<Entities.Customer> existentCustomers = new List<Entities.Customer>() {
            new Entities.Customer() { FirstName= "Customer1", LastName = "Customer1", Email="customer1@mail.com" },
            new Entities.Customer() { FirstName= "Customer2", LastName = "Customer2", Email="customer2@mail.com" },
            new Entities.Customer() { FirstName= "Customer3", LastName = "Customer3", Email="customer3@mail.com" },
        };
        public Task<bool> ExistsByEmail(string email)
        {
            bool customerExists = existentCustomers.Any(x => x.Email == email);
            return Task.FromResult(customerExists);
        }
    }
}
