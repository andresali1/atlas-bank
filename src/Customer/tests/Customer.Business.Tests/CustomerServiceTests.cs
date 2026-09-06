namespace Customer.Business.Tests
{
    public class CustomerServiceTests
    {
        [Fact]
        public void CreateCustomer_WhenFirstNameIsEmpty_ShouldRejectCustomer()
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

            // Act
            Action act = () => customerService.Create(customer);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("First Name is required", exception.Message);
        }
        [Fact]
        public void CreateCustomer_WhenLastNameIsEmpty_ShouldRejectCustomer()
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

            // Act
            Action act = () => customerService.Create(customer);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Last Name is required", exception.Message);
        }
        [Fact]
        public void CreateCustomer_WhenEmailIsEmpty_ShouldRejectCustomer()
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

            // Act
            Action act = () => customerService.Create(customer);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Email is required", exception.Message);
        }
        [Fact]
        public void CreateCustomer_WhenEmailAlreadyExists_ShouldRejectCustomer()
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

            // Act
            Action act = () => customerService.Create(customer);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Email already exists", exception.Message);
        }
        [Fact]
        public void CreateCustomer_WithValidData_ShouldCreateCustomer()
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
            Entities.Customer createdCustomer = customerService.Create(customer);

            // Assert
            Assert.Equal(customer.FirstName, createdCustomer.FirstName);
            Assert.Equal(customer.LastName, createdCustomer.LastName);
            Assert.Equal(customer.Email, createdCustomer.Email);
        }
    }
}
