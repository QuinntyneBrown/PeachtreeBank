using PeachtreeBank.Core.Enums;
using PeachtreeBank.Core.Models;
using PeachtreeBank.Domain.Features.Transactions;
using System;

namespace PeachtreeBank.Domain.Features.Extensions
{
    public static class TransactionExtensions
    {
        public static TransactionDto ToDto(this Transaction transaction)
            => new TransactionDto
            {
                TransactionId = transaction.TransactionId,
                CategoryCode = Enum.GetName(typeof(CategoryCode), transaction.CategoryCode),
                TransactionType = Enum.GetName(typeof(TransactionType), transaction.TransactionType)
            };
    }
}
