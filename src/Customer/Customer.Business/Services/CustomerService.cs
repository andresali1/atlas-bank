using Customer.Contracts.Interfaces;

namespace Customer.Business.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public async Task<Entities.Customer> Create(Entities.Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.FirstName))
            {
                throw new ArgumentException("First Name is required");
            }
            if (string.IsNullOrWhiteSpace(customer.LastName))
            {
                throw new ArgumentException("Last Name is required");
            }
            if (string.IsNullOrWhiteSpace(customer.Email))
            {
                throw new ArgumentException("Email is required");
            }
            if (await customerRepository.ExistsByEmail(customer.Email))
            {
                throw new ArgumentException("Email already exists");
            }

            return customer;
        }
    }
}
