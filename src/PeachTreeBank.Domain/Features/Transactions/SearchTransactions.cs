using MediatR;
using System.Threading.Tasks;
using System.Threading;
using PeachtreeBank.Core.Data;

namespace PeachTreeBank.Domain.Features.Transactions
{
    public class SearchTransactions
    {
        public class Request : IRequest<Response> { 
        
        }

        public class Response
        {

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