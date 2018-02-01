using System;
using System.Reflection;

namespace CheckArcanoidLibrary.Attributes
{
    public class EnumAttributesBaseLogic
    {
        public static CommandEventArgsAttribute  GetAttributeValue<TEnum>(TEnum enumValue)
        {
            FieldInfo fieldInfo = typeof(TEnum).GetField(enumValue.ToString());

            return (CommandEventArgsAttribute) Attribute.GetCustomAttribute(fieldInfo, typeof(CommandEventArgsAttribute));
        }
    }
}