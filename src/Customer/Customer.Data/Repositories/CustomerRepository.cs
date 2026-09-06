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
        public async Task<bool> ExistsByEmail(string email)
        {
            return await _context.Customers.AnyAsync(c => c.Email == email);
        }
    }
}
