using RobotObjects.Enumerables;

namespace RobotObjects.Base
{
    /// <summary>
    /// Базовый класс для двигающихся объектов
    /// </summary>
    public class BaseMove
    {
        #region Открытые свойства

        /// <summary>
        /// Индекс строки для перемещения
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Индекс столбца для перемещения
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// Направление движения
        /// </summary>
        public RouteMove RouteMove { get; set; }

        #endregion
    }
}