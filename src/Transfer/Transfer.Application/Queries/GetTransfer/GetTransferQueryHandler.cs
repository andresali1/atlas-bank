using MediatR;
using Transfer.Application.Interfaces;

namespace Transfer.Application.Queries.GetTransfer
{
    public class GetTransferQueryHandler
    : IRequestHandler<GetTransferQuery, Domain.Transfer?>
    {
        private readonly ITransferRepository repository;

        public GetTransferQueryHandler(
            ITransferRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Domain.Transfer?> Handle(
            GetTransferQuery request,
            CancellationToken cancellationToken)
        {
            return await repository.GetById(request.Id);
        }
    }
}
