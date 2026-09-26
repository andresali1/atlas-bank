using Transfer.Application.Interfaces;

namespace Transfer.Application.Tests.Repositories
{
    public class FakeTransferRepository : ITransferRepository
    {
        public List<Domain.Transfer> Transfers { get; } = new List<Domain.Transfer>() {
            Domain.Transfer.Create(1, 2, 50),
            Domain.Transfer.Create(2, 1, 150),
            Domain.Transfer.Create(1, 3, 20),
        };

        public Task<Domain.Transfer> Add(Domain.Transfer transfer)
        {
            Transfers.Add(transfer);

            return Task.FromResult(transfer);
        }

        public Task<Domain.Transfer?> GetById(int id)
        {
            var transfer = Transfers.FirstOrDefault(x => x.Id == id);

            return Task.FromResult(transfer);
        }
    }
}
