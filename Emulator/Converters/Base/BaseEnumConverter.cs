using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using Emulator.AttributeLogic.Models;

namespace Emulator.Converters.Base
{
    /// <summary>
    /// Базовый класс конвертер для преобразования перечислений
    /// </summary>
    [ValueConversion(typeof(Enum), typeof(IEnumerable<ValueDescriptionEnum<IConvertible>>))]
    public class BaseEnumConverter<TEnum> : BaseConverter
    {
        #region Защищенные свойства

        /// <summary>
        /// Свойство для конвертирования выбранного перечисления
        /// </summary>
        protected IEnumerable<ValueDescriptionEnum<TEnum>> ValueDescriptionConllection { get; set; }

        #endregion

        #region Методы

        /// <summary>
        /// Метод конвертирующий значение исходящее от источника к приемнику
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ValueDescriptionConllection;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        #endregion
    }
}