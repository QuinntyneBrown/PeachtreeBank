using MediatR;
using Microsoft.AspNetCore.Mvc;
using PeachtreeBank.Domain.Features.Transactions;
using System.Net;
using System.Threading.Tasks;

namespace PeachTreeBank.Api.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionsController
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator) => _mediator = mediator;

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpsertTransaction.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpsertTransaction.Response>> Update([FromBody]UpsertTransaction.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{transactionId}")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveTransaction.Response), (int)HttpStatusCode.OK)]
        public async Task Remove([FromRoute]RemoveTransaction.Request request)
            => await _mediator.Send(request);            

        [HttpGet("{transactionId}")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTransactionById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTransactionById.Response>> GetById([FromRoute]GetTransactionById.Request request)
            => await _mediator.Send(request);

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTransactions.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTransactions.Response>> Get()
            => await _mediator.Send(new GetTransactions.Request());
    }
}
