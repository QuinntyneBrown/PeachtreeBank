using Newtonsoft.Json;
using PeachtreeBank.Core.Data;
using PeachtreeBank.Core.Enums;
using PeachtreeBank.Core.Models;
using PeachtreeBank.Domain.Features.Transactions;
using System;
using System.Collections.Generic;

namespace PeachtreeBank.Api.Seeding
{
    public static class SeedData
    {
        public static void Seed(PeachtreeBankDbContext dbContext)
        {
            var json = StaticFileLocator.GetAsString("transactions.json");
            var jsonObject = JsonConvert.DeserializeObject<GetTransactions.Response>(json);
            
            foreach(var transaction in jsonObject.Transactions)
            {
                dbContext.Transactions.Add(new Transaction
                {
                    TransactionDate = new DateTime(1970, 01, 01).AddMilliseconds(transaction.TransactionDate),
                    MerchantLogo = transaction.MerchantLogo,
                    Merchant = transaction.Merchant,
                    Amount = float.Parse(transaction.Amount),
                    TransactionType = (TransactionType)Enum.Parse(typeof(TransactionType), transaction.TransactionType.Replace(" ",string.Empty))
            });
            }

            dbContext.SaveChanges();

        }
    }
}
