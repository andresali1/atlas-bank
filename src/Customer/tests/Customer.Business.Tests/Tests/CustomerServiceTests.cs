using Customer.Business.Services;
using Customer.Business.Tests.Repositories;
using Customer.Contracts.Interfaces;

namespace Customer.Business.Tests.Tests
{
    public class CustomerServiceTests
    {
        [Fact]
        public async Task CreateCustomer_WhenFirstNameIsEmpty_ShouldRejectCustomer()
        {
            // Arrange
            ICustomerRepository customerRepo = new FakeCustomerRepository();
            CustomerService customerService = new CustomerService(customerRepo);
            Entities.Customer customer = new Entities.Customer
            {
                FirstName = "",
                LastName = "Salinas",
                Email = "andres@mail.com"
            };

            // Assert
            ArgumentException exception = await Assert.ThrowsAsync<ArgumentException>(() => customerService.Create(customer));
            Assert.Equal("First Name is required", exception.Message);
        }
        [Fact]
        public async Task CreateCustomer_WhenLastNameIsEmpty_ShouldRejectCustomer()
        {
            // Arrange
            ICustomerRepository customerRepo = new FakeCustomerRepository();
            CustomerService customerService = new CustomerService(customerRepo);
            Entities.Customer customer = new Entities.Customer
            {
                FirstName = "Andrés",
                LastName = "",
                Email = "andres@mail.com"
            };

            // Assert
            ArgumentException exception = await Assert.ThrowsAsync<ArgumentException>(() => customerService.Create(customer));
            Assert.Equal("Last Name is required", exception.Message);
        }
        [Fact]
        public async Task CreateCustomer_WhenEmailIsEmpty_ShouldRejectCustomer()
        {
            // Arrange
            ICustomerRepository customerRepo = new FakeCustomerRepository();
            CustomerService customerService = new CustomerService(customerRepo);
            Entities.Customer customer = new Entities.Customer
            {
                FirstName = "Andrés",
                LastName = "Salinas",
                Email = ""
            };

            // Assert
            ArgumentException exception = await Assert.ThrowsAsync<ArgumentException>(() => customerService.Create(customer));
            Assert.Equal("Email is required", exception.Message);
        }
        [Fact]
        public async Task CreateCustomer_WhenEmailAlreadyExists_ShouldRejectCustomer()
        {
            // Arrange
            ICustomerRepository customerRepo = new FakeCustomerRepository();
            CustomerService customerService = new CustomerService(customerRepo);
            Entities.Customer customer = new Entities.Customer
            {
                FirstName = "Andrés",
                LastName = "Salinas",
                Email = "customer3@mail.com"
            };

            // Assert
            ArgumentException exception = await Assert.ThrowsAsync<ArgumentException>(() => customerService.Create(customer));
            Assert.Equal("Email already exists", exception.Message);
        }
        [Fact]
        public async Task CreateCustomer_WithValidData_ShouldCreateCustomer()
        {
            // Arrange
            ICustomerRepository customerRepo = new FakeCustomerRepository();
            CustomerService customerService = new CustomerService(customerRepo);
            Entities.Customer customer = new Entities.Customer
            {
                FirstName = "Andrés",
                LastName = "Salinas",
                Email = "andres@mail.com"
            };

            // Act
            Entities.Customer createdCustomer = await customerService.Create(customer);

            // Assert
            Assert.Equal(customer.FirstName, createdCustomer.FirstName);
            Assert.Equal(customer.LastName, createdCustomer.LastName);
            Assert.Equal(customer.Email, createdCustomer.Email);
        }
    }
}
