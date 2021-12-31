using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Utilities.Extensions
{
    public static class StringExtension
    {
        public static string Fixed(this string input)
        {
            if (input != null)
            {
                return input.Trim().ToLower();
            }

            return null;
        }

        public static string ToTooman(this int amount)
        {
            return amount.ToString("#,#");
        }
    }
}
