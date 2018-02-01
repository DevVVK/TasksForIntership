using RobotObjects.Enumerables;

namespace Emulator.AttributeLogic.Models
{
    /// <summary>
    /// Класс представляющий модель значений перечисления
    /// </summary>
    public class ValueDescriptionEnum<TEnum>
    {
        #region Открытые свойства

        /// <summary>
        /// Значение перечисления
        /// </summary>
        public TEnum Value { get; set; }

        /// <summary>
        /// Значение описания
        /// </summary>
        public string Description { get; set; }

        #endregion
    }
}