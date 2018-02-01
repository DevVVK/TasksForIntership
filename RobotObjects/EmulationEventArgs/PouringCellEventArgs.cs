using System;
using RobotObjects.Enumerables;

namespace RobotObjects.EmulationEventArgs
{
    /// <summary>
    /// Класс представляющий аргументы события заливки ячейки 
    /// </summary>
    public class PouringCellEventArgs : EventArgs
    {
        #region Открытые для чтения свойства

        /// <summary>
        /// Индекс местоположения ячейки в строке
        /// </summary>
        public int Row { get; }

        /// <summary>
        /// Индекс местоположения ячейки в столбце 
        /// </summary>
        public int Column { get; }

        /// <summary>
        /// Цвет ячейки, в который она перекрашена
        /// </summary>
        public ColorCell Color { get; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="row">индекс строки</param>
        /// <param name="column">индекс столбца</param>
        /// <param name="color">цвет</param>
        public PouringCellEventArgs(int row, int column, ColorCell color)
        {
            Row = row;
            Column = column;
            Color = color;
        }

        #endregion
    }
}