using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop.Utils
{
    public static class StringFormat
    {
        public static string Money(decimal money)
        {
            return string.Format("{0:#,###}", money);
        }
    }
}