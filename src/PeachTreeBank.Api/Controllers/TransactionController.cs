using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeachtreeBank.Domain.Features.Transactions;
using System.Threading.Tasks;

namespace PeachtreeBank.Api.Controllers
{
    [ApiController]
    [Route("api/{{ entityNameCamelCasePlural }}")]
    public class TransactionsController
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator) => _mediator = mediator;

        
        [HttpDelete("{transactionId}")]
        public async Task Remove([FromRoute]RemoveTransaction.Request request)
            => await _mediator.Send(request);            

        [HttpGet("{transactionId}")]
        public async Task<ActionResult<GetTransactionById.Response>> GetById([FromRoute]GetTransactionById.Request request)
            => await _mediator.Send(request);

        [HttpGet]
        public async Task<ActionResult<GetTransactions.Response>> Get()
            => await _mediator.Send(new GetTransactions.Request());
    }
}
