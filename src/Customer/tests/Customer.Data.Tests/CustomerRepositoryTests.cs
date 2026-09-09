using Customer.Data.Persistence;
using Customer.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Customer.Data.Tests
{
    public class CustomerRepositoryTests
    {
        [Fact]
        public async Task AddCustomer_ShouldPersistCustomer()
        {
            var connectionString =
                "Server=localhost;Port=3307;Database=atlas_customer;User=customer;Password=customer;";

            var options = new DbContextOptionsBuilder<CustomerDbContext>()
                .UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString))
                .Options;

            await using var context = new CustomerDbContext(options);

            var repository = new CustomerRepository(context);

            var customer = new Entities.Customer
            {
                FirstName = "Integration",
                LastName = "Test",
                Email = $"integration-{Guid.NewGuid()}@test.com"
            };

            var createdCustomer = await repository.Add(customer);

            Assert.NotEqual(0, createdCustomer.Id);

            var customerInDatabase = await context.Customers
                .FirstOrDefaultAsync(x => x.Email == customer.Email);

            Assert.NotNull(customerInDatabase);
            Assert.Equal(customer.FirstName, customerInDatabase.FirstName);
            Assert.Equal(customer.LastName, customerInDatabase.LastName);

            context.Customers.Remove(customerInDatabase);
            await context.SaveChangesAsync();
        }
    }
}
