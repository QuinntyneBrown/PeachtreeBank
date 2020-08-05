using PeachTreeBank.Core.Models;
using PeachTreeBank.Domain.Features.Transactions;

namespace PeachTreeBank.Domain.Features.Extensions
{
    public static class TransactionExtensions
    {
        public static TransactionDto ToDto(this Transaction transaction)
            => new TransactionDto
            {

            };
    }
}
