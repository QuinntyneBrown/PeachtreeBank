using MediatR;
using Microsoft.EntityFrameworkCore;
using PeachtreeBank.Core.Data;
using PeachtreeBank.Domain.Features.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PeachtreeBank.Domain.Features.Transactions
{
    public class GetTransactions
    {
        public class Request : IRequest<Response> { }

        public class Response
        {
            public ICollection<TransactionDto> Transactions { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IPeachtreeBankDbContext _context { get; set; }
            public Handler(IPeachtreeBankDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) 
                => new Response { 
                    Transactions = await _context.Transactions.Select(x => x.ToDto()).ToListAsync()    
                };            
        }
    }
}
