using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transfer.Api.Models;
using Transfer.Application.Commands.CreateTransfer;
using Transfer.Application.Queries.GetTransfer;

namespace Transfer.Api.Controllers
{
    [ApiController]
    [Route("transfers")]
    public class TransfersController : ControllerBase
    {
        private readonly IMediator mediator;

        public TransfersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateTransferRequest request)
        {
            var command = new CreateTransferCommand
            {
                SourceAccountId = request.SourceAccountId,
                TargetAccountId = request.TargetAccountId,
                Amount = request.Amount
            };

            var result = await mediator.Send(command);

            var response = new TransferResponse
            {
                Id = result.Id,
                SourceAccountId = result.SourceAccountId,
                TargetAccountId = result.TargetAccountId,
                Amount = result.Amount
            };

            return Created(
                $"/transfers/{result.Id}",
                response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetTransferQuery
            {
                Id = id
            };

            var result = await mediator.Send(query);

            if (result is null)
                return NotFound();

            var response = new TransferResponse
            {
                Id = result.Id,
                SourceAccountId = result.SourceAccountId,
                TargetAccountId = result.TargetAccountId,
                Amount = result.Amount
            };

            return Ok(response);
        }
    }
}
