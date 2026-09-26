namespace Transfer.Application.Interfaces
{
    public interface ITransferRepository
    {
        Task<Domain.Transfer> Add(Domain.Transfer transfer);
        Task<Domain.Transfer?> GetById(int id);
    }
}
