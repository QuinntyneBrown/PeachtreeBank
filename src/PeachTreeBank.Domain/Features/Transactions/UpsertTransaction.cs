using MediatR;
using System.Threading.Tasks;
using System.Threading;
using PeachtreeBank.Core.Data;
using PeachtreeBank.Domain.Features.Transactions;
using FluentValidation;
using System.Linq;
using PeachtreeBank.Domain.Features.Extensions;
using PeachtreeBank.Core.Models;

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
                var transaction = _context.Transactions.FirstOrDefault(x => x.TransactionId == request.Transaction.TransactionId);

                if(transaction == null)
                {
                    transaction = new Transaction();
                }

                transaction.Merchant = request.Transaction.Merchant;
                transaction.MerchantLogo = request.Transaction.MerchantLogo;
                transaction.CategoryCode = request.Transaction.CategoryCode.ToCategoryCodeEnum();
                transaction.TransactionDate = request.Transaction.TransactionDate.ToDateTime();
                transaction.Amount = float.Parse(request.Transaction.Amount);
                transaction.TransactionType = request.Transaction.TransactionType.ToTransactionTypeEnum();

                return new Response() { };
            }
        }
    }
}
