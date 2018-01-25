using RobotObjects.Objects.Base;
using RobotObjects.Objects.Enumerables;

namespace RobotObjects.Objects.Grid
{
    /// <summary>
    /// Класс представляющий ячейку сетки
    /// </summary>
    public class CellRobot : BaseRobot
    {
        #region Открытые свойства
        
        /// <summary>
        /// Цвет ячейки
        /// </summary>
        public ColorCell Color { get; set; }

        /// <summary>
        /// Проходима ли ячейка
        /// </summary>
        public bool IsMove { get; set; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструтор для инициализатора объета
        /// </summary>
        public CellRobot()
        {
            
        }

        /// <summary>
        /// Конструктор по умолчанию 
        /// </summary>
        /// <param name="width">ширина ячейки</param>
        /// <param name="height">длинна ячейки</param>
        /// <param name="color">цвет ячейки</param>
        /// <param name="isMove">если true - ячейка проходима, если false - ячейка не проходима</param>
        public CellRobot(double width, double height, ColorCell color, bool isMove) : base(width, height)
        {
            Color = color;
            IsMove = isMove;
        }

        #endregion
    }
}