using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Robot.Converters
{
    /// <summary>
    /// Класс представляющий конвертер для преобразования из типа <see cref="null"/> в тип <see cref="int"/>
    /// </summary>
    public class NullToIntConverter : IValueConverter
    {
        #region Методы

        /// <summary>
        /// Метод конвертирующий значение исходящее от источника к приемнику
        /// </summary>
        /// <param name="value">значение исходящее от источника к приемнику</param>
        /// <param name="targetType"></param>
        /// <param name="parameter">передаваемый параметр</param>
        /// <param name="culture">культурные настройки</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is int source ? source : 0;
        }

        /// <summary>
        /// Метод конвертирующий значение передаваемое от приемника к источнику
        /// </summary>
        /// <param name="value">значение передаваемое от источника к применику</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // так как в разметке не установлено свойство двунаправленой передачи данных используется значение - метка
            return DependencyProperty.UnsetValue;
        }

        #endregion
    }
}