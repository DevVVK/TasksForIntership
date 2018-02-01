using RobotObjects.Base;
using RobotObjects.Enumerables;

namespace RobotObjects.Objects
{
    /// <summary>
    /// Класс предстввяющий обьект Robot
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
        /// <param name="row">начальное положение робота(индекс строки)</param>
        /// <param name="column">начальное положение робота(индекс столбца)</param>
        public Robot(int row, int column)
        {
            Row = row;
            Column = column;
            RouteMove = RouteMove.Right;
        }

        #endregion
    }
}