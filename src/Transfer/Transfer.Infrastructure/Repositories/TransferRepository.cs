using Microsoft.EntityFrameworkCore;
using Transfer.Application.Interfaces;
using Transfer.Infrastructure.Persistence;

namespace Transfer.Infrastructure.Repositories
{
    public class TransferRepository : ITransferRepository
    {
        private readonly TransferDbContext _context;
        public TransferRepository(TransferDbContext context)
        {
            _context = context;
        }
        public async Task<Domain.Transfer> Add(Domain.Transfer transfer)
        {
            await _context.Transfers.AddAsync(transfer);
            await _context.SaveChangesAsync();

            return transfer;
        }

        public async Task<Domain.Transfer?> GetById(int id)
        {
            return await _context.Transfers.FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
