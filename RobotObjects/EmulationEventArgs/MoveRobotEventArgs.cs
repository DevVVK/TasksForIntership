using System;

namespace RobotObjects.EmulationEventArgs
{
    /// <summary>
    /// Класс представляющий аргументы события движения робота
    /// </summary>
    public class MoveRobotEventArgs : EventArgs
    {
        #region Открытые свойства

        /// <summary>
        /// Индекс местоположение робота в строке
        /// </summary>
        public int Row { get; }

        /// <summary>
        /// Индекс местоположения робота в столбце
        /// </summary>
        public int Column { get; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="row">индекс строки</param>
        /// <param name="column">индекс столбца</param>
        public MoveRobotEventArgs(int row, int column)
        {
            Row = row;
            Column = column;
        }

        #endregion 
    }
}