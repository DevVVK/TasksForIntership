using System;
using Users.BLL.BusinessModels.Date.BaseDate;

namespace Users.BLL.BusinessModels.Date
{
    public class DateFormConverter : BaseDateConverter
    {
        public DateForm Form { get; }

        public DateFormConverter(DateTime dateTime)
        {
            var formatInfo = Culture.DateTimeFormat;
            Form = new DateForm
            {
                Year = dateTime.Year,
                Month = formatInfo.GetMonthName(dateTime.Month),
                Day = dateTime.Day
            };
        }
    }
}