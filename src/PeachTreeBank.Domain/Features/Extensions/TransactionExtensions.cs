using BuildingBlocks;
using PeachtreeBank.Core.Enums;
using PeachtreeBank.Core.Models;
using PeachtreeBank.Domain.Features.Transactions;
using System;

namespace PeachtreeBank.Domain.Features.Extensions
{
    public static class CategoryCodeExtensions
    {
        public static string ToColorCode(this CategoryCode categoryCode)
        {
            string colorCode = categoryCode switch
            {
                CategoryCode.Associations => "#d51271",
                CategoryCode.AmusementAndEntertainment => "#12a580",
                CategoryCode.BarsAndResturants => "#c12020",
                CategoryCode.BusinessServices => "#c89616",
                CategoryCode.ClothingAndAccessories => "#e25a2c",
                CategoryCode.ContractedServices => "#1180aa",
                CategoryCode.DirectMarketing => "#fbbb1b",
                _ => "#d51271",
            };
            return colorCode;
        }

        public static CategoryCode ToCategoryCodeEnum(this string categoryCode)
        {
            var categoryCodeEnum = CategoryCode.Associations;

            switch(categoryCode)
            {
                case "#d51271":
                    categoryCodeEnum = CategoryCode.Associations;
                    break;
                
                case "#12a580":
                    categoryCodeEnum = CategoryCode.AmusementAndEntertainment;
                    break;
                
                case "#c12020":
                    categoryCodeEnum = CategoryCode.BarsAndResturants;
                    break;

                case "#c89616":
                    categoryCodeEnum = CategoryCode.BusinessServices;
                    break;
                
                case "#e25a2c":
                    categoryCodeEnum = CategoryCode.ClothingAndAccessories;
                    break;
                
                case "#1180aa":
                    categoryCodeEnum = CategoryCode.ContractedServices;
                    break;
                
                case "#fbbb1b":
                    categoryCodeEnum = CategoryCode.DirectMarketing;
                    break;
            }

            return categoryCodeEnum;
        }
    }

    public static class TransactionTypeExtensions
    {
        public static DateTime ToDateTime(this double value)
        {
            return new DateTime(1970, 01, 01).AddMilliseconds(value);
        }

        public static TransactionType ToTransactionTypeEnum(this string value)
        {
            return (TransactionType)Enum.Parse(typeof(TransactionType), value.Replace(" ", string.Empty));
        }
    }
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
