using MediatR;

namespace Transfer.Application.Queries.GetTransfer
{
    public class GetTransferQuery : IRequest<Domain.Transfer?>
    {
        public int Id { get; init; }
    }
}
