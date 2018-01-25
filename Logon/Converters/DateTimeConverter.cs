using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Logon.Converters
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null ? ((DateTime) value).ToString("MM.dd.yyyy") : DateTime.Now.ToShortDateString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}