namespace Customer.Business
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public Entities.Customer Create(Entities.Customer customer)
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
            if (customerRepository.ExistsByEmail(customer.Email))
            {
                throw new ArgumentException("Email already exists");
            }

            return customer;
        }
    }
}
