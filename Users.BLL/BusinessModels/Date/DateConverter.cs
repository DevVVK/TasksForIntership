using System;
using System.Globalization;

namespace Users.BLL.BusinessModels.Date
{
    public class DateConverter
    {
        public DateTime DateTime { get; }

        public DateConverter(int year, string month, int day)
        {
            var strDate = $"{day}/{month}/{year}";
            DateTime = Convert.ToDateTime(strDate);
        }
    }
}