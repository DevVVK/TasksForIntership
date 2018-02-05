using System;
using RobotObjects.Objects;

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

        /// <summary>
        /// Коллекция ячеек в сетке
        /// </summary>
        public Cell[,] Cells { get; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="gridParameters">Сетка</param>
        /// <param name="robotPoint">Робот</param>
        public InitializeEmulationEventArgs(Grid gridParameters, Robot robotPoint)
        {
            RowCount = gridParameters.RowCount;
            ColumnCount = gridParameters.ColumnCount;
            RowPoint = robotPoint.Row;
            ColumnPoint = robotPoint.Column;
            Cells = gridParameters.Cells;
        }

        #endregion
    }
}