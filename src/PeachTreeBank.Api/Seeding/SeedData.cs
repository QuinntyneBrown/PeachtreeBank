using Newtonsoft.Json;
using PeachtreeBank.Core.Data;
using PeachtreeBank.Core.Models;
using PeachtreeBank.Domain.Features.Extensions;
using PeachtreeBank.Domain.Features.Transactions;

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
                    TransactionDate = transaction.TransactionDate.ToDateTime(),
                    MerchantLogo = transaction.MerchantLogo,
                    Merchant = transaction.Merchant,
                    Amount = float.Parse(transaction.Amount),
                    CategoryCode = transaction.CategoryCode.ToCategoryCodeEnum(),
                    TransactionType = transaction.TransactionType.ToTransactionTypeEnum()
                });
            }

            dbContext.SaveChanges();
        }
    }
}
