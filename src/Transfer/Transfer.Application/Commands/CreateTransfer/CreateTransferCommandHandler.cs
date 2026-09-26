using MediatR;
using Transfer.Application.Interfaces;

namespace Transfer.Application.Commands.CreateTransfer
{
    public class CreateTransferCommandHandler
    : IRequestHandler<CreateTransferCommand, Domain.Transfer>
    {
        private readonly ITransferRepository repository;

        public CreateTransferCommandHandler(
            ITransferRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Domain.Transfer> Handle(
            CreateTransferCommand request,
            CancellationToken cancellationToken)
        {
            var transfer = Domain.Transfer.Create(
                request.SourceAccountId,
                request.TargetAccountId,
                request.Amount);

            return await repository.Add(transfer);
        }
    }
}
