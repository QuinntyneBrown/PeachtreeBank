using System;

namespace PeachtreeBank.Domain.Features.Transactions
{
    public class TransactionDto
    {
        public Guid TransactionId { get; set; }
        public string CategoryCode { get; set; }
        public string Amount { get; set; }
        public double TransactionDate { get; set; }
        public string Merchant { get; set; }
        public string MerchantLogo { get; set; }
        public string TransactionType { get; set; }
    }

}
