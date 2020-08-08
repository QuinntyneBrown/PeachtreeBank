using PeachtreeBank.Core.BuildingBlocks;
using PeachtreeBank.Core.Enums;
using PeachtreeBank.Core.Models;
using PeachtreeBank.Domain.Features.Transactions;
using System;

namespace PeachtreeBank.Domain.Features.Extensions
{
    public static class TransactionExtensions
    {

        public static TransactionDto ToDto(this Transaction transaction)
        {
            return new TransactionDto
            {
                TransactionId = transaction.TransactionId,
                CategoryCode = transaction.CategoryCode.ToColorCode(),
                TransactionType = new NamingConventionConverter().Convert(NamingConvention.TitleCase, Enum.GetName(typeof(TransactionType), transaction.TransactionType)),
                Amount = $"{transaction.Amount}",
                Merchant = transaction.Merchant,
                MerchantLogo = transaction.MerchantLogo,
                TransactionDate = transaction.TransactionDate.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds
            };
        }
 
    }
}
