using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Emulator.Converters.Base
{
    /// <summary>
    /// Базовый класс конвертер
    /// </summary>
    public abstract class BaseConverter : MarkupExtension, IValueConverter
    {
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}