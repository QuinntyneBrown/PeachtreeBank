using PeachTreeBank.Core.Enums;
using PeachTreeBank.Core.Models;
using PeachTreeBank.Domain.Features.Transactions;
using System;

namespace PeachTreeBank.Domain.Features.Extensions
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
