using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using PeachtreeBank.Domain.Features.Transactions;
using System;

namespace PeachtreeBank.Api.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionsController
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator) => _mediator = mediator;

        [HttpPut(Name = "UpsertTransactionRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpsertTransaction.Response), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<UpsertTransaction.Response>> Upsert([FromBody] UpsertTransaction.Request request)
        {
            var response = await _mediator.Send(request);

            return new CreatedAtActionResult(nameof(GetById), nameof(TransactionsController), new { id = response.Transaction.TransactionId }, response);
        }
        
        [HttpDelete("{transactionId}", Name = "RemoveTransactionRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task Remove([FromRoute]RemoveTransaction.Request request)
            => await _mediator.Send(request);            

        [HttpGet("{transactionId}", Name = "GetTransactionByIdRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTransactionById.Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GetTransactionById.Response>> GetById([FromRoute]GetTransactionById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Transaction == null)
                return new NotFoundObjectResult(request.TransactionId);

            return response;
        }

        [HttpGet(Name = "GetTransactionsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTransactions.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTransactions.Response>> Get()
            => await _mediator.Send(new GetTransactions.Request());
    }
}
