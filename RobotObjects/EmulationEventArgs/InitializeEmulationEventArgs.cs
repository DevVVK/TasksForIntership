using System;

namespace RobotObjects.EmulationEventArgs
{
    /// <summary>
    /// Класс представляющий событие создания сетки и установление местоположения робота в этой сетке
    /// </summary>
    public class InitializeEmulationEventArgs : EventArgs
    {
        #region Открытые для чтения свойства

        /// <summary>
        /// Количество строк в сетке
        /// </summary>
        public int RowCount { get; }

        /// <summary>
        /// Количество столбцов в сетке
        /// </summary>
        public int ColumnCount { get; }

        /// <summary>
        /// Индекс местоположения робота в строке
        /// </summary>
        public int RowPoint { get; }

        /// <summary>
        /// Индекс местоположения робота в столбце
        /// </summary>
        public int ColumnPoint { get; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="rowCount">количество строк</param>
        /// <param name="columnCount">количество столбцов</param>
        /// <param name="rowPoint">индекс строки</param>
        /// <param name="columnPoint">индекс столбца</param>
        public InitializeEmulationEventArgs(int rowCount, int columnCount, int rowPoint, int columnPoint)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;
            RowPoint = rowPoint;
            ColumnPoint = columnPoint;
        }

        #endregion
    }
}