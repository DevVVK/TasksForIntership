using System;

namespace CheckArcanoidLibrary.Attributes
{
    public class EnumAttributesBaseLogic
    {
        public static CommandEventArgsAttribute  GetAttributeValue<TEnum>(TEnum enumValue)
        {
            var fieldInfo = typeof(TEnum).GetField(enumValue.ToString());

            return (CommandEventArgsAttribute) Attribute.GetCustomAttribute(fieldInfo, typeof(CommandEventArgsAttribute));
        }
    }
}