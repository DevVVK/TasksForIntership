using RobotObjects.Objects.Base;
using RobotObjects.Objects.Enumerables;

namespace RobotObjects.Objects
{
    /// <summary>
    /// Класс предстввяющий обьект см. <see cref="Robot"/>
    /// </summary>
    public class Robot : BaseMove
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию для инициализатора объектов
        /// </summary>
        public Robot()
        {
            
        }

        /// <summary>
        /// Конструктор по умолчанию 
        /// </summary>
        /// <param name="width">ширина ячейки</param>
        /// <param name="height">высота ячейки</param>
        /// <param name="row">начальное положение робота(индекс строки)</param>
        /// <param name="column">начальное положение робота(индекс столбца)</param>
        public Robot(double width, double height, int row, int column) : base(width, height, row, column)
        {
            RouteMove = RouteMove.Right;
        }

        #endregion
    }
}