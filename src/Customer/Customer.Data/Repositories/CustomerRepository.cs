using Customer.Contracts.Interfaces;
using Customer.Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Customer.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _context;
        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }
        public async Task<Entities.Customer> GetById(int id)
        {
            var customer = await _context.FindAsync<Entities.Customer>(id);

            if (customer is null)
            {
                throw new KeyNotFoundException(
                    $"Customer with Id {id} wasn't found");
            }

            return customer;
        }
        public async Task<bool> ExistsByEmail(string email)
        {
            return await _context.Customers.AnyAsync(c => c.Email == email);
        }
        public async Task<Entities.Customer> Add(Entities.Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return customer;
        }
    }
}
