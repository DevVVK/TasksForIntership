using RobotObjects.Base;
using RobotObjects.Enumerables;

namespace RobotObjects.Objects
{
    /// <summary>
    /// Класс предстввяющий обьект Robot
    /// </summary>
    public class Robot : BaseMove
    {
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

        /// <summary>
        /// Конструктор для инициализатора объектов
        /// </summary>
        public Robot()
        {
        }

        /// <summary>
        /// Конструктор по умолчанию 
        /// </summary>
        /// <param name="row">начальное положение робота(индекс строки)</param>
        /// <param name="column">начальное положение робота(индекс столбца)</param>
        public Robot(int row, int column, RouteMove route)
        {
            Row = row;
            Column = column;
            RouteMove = route;
        }
    }
}