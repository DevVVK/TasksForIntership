using System;
using System.ComponentModel;
using System.Reflection;

namespace Emulator.AttributeLogic
{
    /// <summary>
    /// Класс получения данных атрибутов
    /// </summary>
    public static class AttributeManager
    {
        #region Открытые методы

        /// <summary>
        /// Метод получения значение атрибута <see cref="DescriptionAttribute"/> (для классов)
        /// </summary>
        /// <param name="classType">тип, который обозначен атрибутом <see cref="DescriptionAttribute"/></param>
        /// <returns></returns>
        public static string GetDescription(Type classType)
        {
            if (!classType.IsClass)
                throw new ArgumentException($"{classType.Name} не является классом");

            var attribute = (DescriptionAttribute) Attribute.GetCustomAttribute(classType, typeof(DescriptionAttribute));

            return attribute?.Description;
        }

        /// <summary>
        /// Получает значение атрибута <see cref="DescriptionAttribute"/>
        /// </summary>
        /// <typeparam name="TEnum">Тип перечисления</typeparam>
        /// <param name="enumField">Значение перечисления</param>
        /// <returns></returns>
        public static string GetEnumDescriptionField<TEnum>(TEnum enumField)
        {
            if (!typeof(TEnum).IsEnum) 
                throw new ArgumentException($"Тип {typeof(TEnum).Name} не является перечислением");

            FieldInfo field = typeof(TEnum).GetField(enumField.ToString());

            var attribute = (DescriptionAttribute) Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

            return attribute?.Description;
        }
        
        /// <summary>
        /// Метод получения списка полей и значения атрибута <see cref="DescriptionAttribute"/>
        /// </summary>
        /// <typeparam name="TEnum">тип перечисления для переменной</typeparam>
        /// <param name="enumerable">тип перечисления</param>
        /// <returns></returns>
        /*public static IEnumerable<ValueDescriptionEnum<TEnum>> GetValueDescriptionsFields<TEnum>()
        {
            if(!typeof(TEnum).IsEnum)
                throw new ArgumentException($"Тип {typeof(TEnum).Name} не является перечислением");

            IEnumerable<ValueDescriptionEnum<TEnum>> list = GetEnumFields(typeof(TEnum))
                .Cast<TEnum>()
                .Select(item => new ValueDescriptionEnum<TEnum> {Value = item, Description = GetEnumDescriptionField(item)})
                .Where(item => item.Description != null).ToList();

            return list;
        }*/

        #endregion

        #region Закрытые методы

        /// <summary>
        /// Получает все поля перечисления 
        /// </summary>
        /// <param name="enumerableType">тип перечисления</param>
        /// <returns></returns>
        private static Array GetEnumFields(Type enumerableType)
        {
            if (!enumerableType.IsEnum)
                throw new ArgumentException($"Тип {enumerableType.Name} не является перечислением");

            return Enum.GetValues(enumerableType);
        }

        #endregion
    }
}