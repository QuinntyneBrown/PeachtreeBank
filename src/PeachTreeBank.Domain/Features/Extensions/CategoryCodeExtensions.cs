using PeachtreeBank.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeachtreeBank.Domain.Features.Extensions
{
    public static class CategoryCodeExtensions
    {
        public static string ToColorCode(this CategoryCode categoryCode)
        {
            var colorCode = "";

            switch (categoryCode)
            {
                default:
                    colorCode = "#fff";
                    break;
            }
            return colorCode;
        }

        public static CategoryCode ToCategoryCodeEnum(this string categoryCode)
        {
            //TODO: Implement logic
            return CategoryCode.Business;
        }
    }
}
