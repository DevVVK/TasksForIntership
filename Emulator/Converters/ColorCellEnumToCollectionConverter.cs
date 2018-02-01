using Emulator.AttributeLogic;
using Emulator.Converters.Base;
using RobotObjects.Enumerables;

namespace Emulator.Converters
{
    /// <summary>
    /// Класс представляющий конвертер значения для перечисления <see cref="ColorCell"/>
    /// </summary>
    public class ColorCellEnumToCollectionConverter : BaseEnumConverter<ColorCell>
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ColorCellEnumToCollectionConverter()
        {
            ValueDescriptionConllection = AttributeManager.GetValueDescriptionsFields<ColorCell>();
        }

        #endregion
    }
}