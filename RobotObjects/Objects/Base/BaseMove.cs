using RobotObjects.Objects.Enumerables;

namespace RobotObjects.Objects.Base
{
    /// <summary>
    /// Базовый класс для двигающихся объектов
    /// </summary>
    public class BaseMove : BaseRobot
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

        #region Конструторы

        /// <summary>
        /// Конструкторы по умолчанию для движущихся объектов
        /// </summary>
        /// <param name="width">ширина объекта</param>
        /// <param name="height">длинна объекта</param>
        /// <param name="row">индекс строки для перемещения</param>
        /// <param name="column">индекс столбца для перемещения</param>
        public BaseMove(double width, double height, int row, int column) : base(width, height)
        {
            Row = row;
            Column = column;
        }

        #endregion

        #region Методы 


        #endregion
    }
}