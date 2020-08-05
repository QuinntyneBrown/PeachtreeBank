using PeachTreeBank.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace PeachTreeBank.Core.Models
{
    public class Transaction
    {
        [Key]
        public Guid TransactionId { get; set; }
        public float Amount { get; set; }
        public CategoryCode CategoryCode { get; set; }
        public string Merchant { get; set; }
        public string MerchantLogo { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }
    }

}
