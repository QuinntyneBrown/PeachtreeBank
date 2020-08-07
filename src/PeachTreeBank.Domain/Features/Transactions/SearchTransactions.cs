using MediatR;
using System.Threading.Tasks;
using System.Threading;
using PeachtreeBank.Core.Data;
using System.Collections;
using PeachtreeBank.Domain.Features.Transactions;
using System.Collections.Generic;

namespace PeachtreeBank.Domain.Features.Transactions
{
    public class SearchTransactions
    {
        public class Request : IRequest<Response> {
            public string Term { get; set; }
        }

        public class Response
        {
            public ICollection<TransactionDto> Transactions { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private IPeachtreeBankDbContext _context { get; set; }

            public Handler(IPeachtreeBankDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
			    return new Response() { };
            }
        }
    }
}
