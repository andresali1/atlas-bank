namespace Customer.Business.Tests
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        private readonly List<Entities.Customer> existentCustomers = new List<Entities.Customer>() {
            new Entities.Customer() { FirstName= "Customer1", LastName = "Customer1", Email="customer1@mail.com" },
            new Entities.Customer() { FirstName= "Customer2", LastName = "Customer2", Email="customer2@mail.com" },
            new Entities.Customer() { FirstName= "Customer3", LastName = "Customer3", Email="customer3@mail.com" },
        };
        public bool ExistsByEmail(string email)
        {
            return existentCustomers.Any(x => x.Email == email);
        }
    }
}
