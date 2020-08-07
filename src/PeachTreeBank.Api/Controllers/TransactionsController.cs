using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using PeachtreeBank.Domain.Features.Transactions;

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
        [ProducesResponseType(typeof(UpsertTransaction.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpsertTransaction.Response>> Upsert([FromBody]UpsertTransaction.Request request)
            => await _mediator.Send(request);
        
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
        public async Task<ActionResult<GetTransactionById.Response>> GetById([FromRoute]GetTransactionById.Request request)
            => await _mediator.Send(request);

        [HttpGet(Name = "GetTransactionsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTransactions.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTransactions.Response>> Get()
            => await _mediator.Send(new GetTransactions.Request());
    }
}
