using RobotObjects.Enumerables;

namespace RobotObjects.Objects
{
    /// <summary>
    /// Класс представляющий ячейку сетки
    /// </summary>
    public class Cell
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
        public Cell()
        {
            
        }

        /// <summary>
        /// Конструктор по умолчанию 
        /// </summary>
        /// <param name="color">цвет ячейки</param>
        /// <param name="isMove">если true - ячейка проходима, если false - ячейка не проходима</param>
        public Cell(ColorCell color, bool isMove)
        {
            Color = color;
            IsMove = isMove;
        }

        #endregion
    }
}