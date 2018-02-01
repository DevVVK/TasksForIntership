using Emulator.AttributeLogic;
using Emulator.Converters.Base;
using RobotObjects.Enumerables;

namespace Emulator.Converters
{
    /// <summary>
    /// Класс представляющий конвертер значений перечисления <see cref="RouteMove"/>
    /// </summary>
    public class RouteMoveEnumToCollectionConverter : BaseEnumConverter<RouteMove>
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public RouteMoveEnumToCollectionConverter()
        {
            ValueDescriptionConllection = AttributeManager.GetValueDescriptionsFields<RouteMove>();
        }

        #endregion
    }
}