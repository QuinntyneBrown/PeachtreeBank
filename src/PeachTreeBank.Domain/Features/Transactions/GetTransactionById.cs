using MediatR;
using System.Threading.Tasks;
using System.Threading;
using PeachtreeBank.Core.Data;
using System;

namespace PeachtreeBank.Domain.Features.Transactions
{
    public class GetTransactionById
    {
        public class Request : IRequest<Response> {
            public Guid TransactionId { get; set; }
        }

        public class Response
        {
            public TransactionDto Transaction { get; set; }
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
