using MediatR;

namespace Transfer.Application.Commands.CreateTransfer
{
    public class CreateTransferCommand : IRequest<Domain.Transfer>
    {
        public int SourceAccountId { get; init; }
        public int TargetAccountId { get; init; }
        public decimal Amount { get; init; }
    }
}
