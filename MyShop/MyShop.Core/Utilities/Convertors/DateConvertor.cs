using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Utilities.Convertors
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();

            return pc.GetYear(date) + "/" + pc.GetMonth(date).ToString("00") + "/" +
                   pc.GetDayOfMonth(date).ToString("00");
        }
    }
}
