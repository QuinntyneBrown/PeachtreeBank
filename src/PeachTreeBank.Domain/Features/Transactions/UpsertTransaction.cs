using MediatR;
using System.Threading.Tasks;
using System.Threading;
using PeachtreeBank.Core.Data;
using PeachtreeBank.Domain.Features.Transactions;
using FluentValidation;

namespace PeachtreeBank.Domain.Features.Transactions
{
    public class UpsertTransaction
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {

            }
        }

        public class Request : IRequest<Response> {
            public TransactionDto Transaction { get; set; }
        }

        public class Response
        {
            public TransactionDto Transaction { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IPeachtreeBankDbContext _context;

            public Handler(IPeachtreeBankDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
			    return new Response() { };
            }
        }
    }
}
