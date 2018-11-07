using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop.Utils
{
    public enum MoneyType
    {
        None,
        VND,
        USD
    }

    public static class StringFormat
    {
        public static string Money(decimal money, MoneyType money_type)
        {
            if (money == 0)
                return String.Empty;

            string result = string.Format("{0:#,###}", money);

            switch (money_type)
            {
                case MoneyType.VND:
                    result = String.Concat(result, "₫");
                    break;
                case MoneyType.USD:
                    result = String.Concat("$", result);
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}