namespace RobotObjects.Objects
{
    /// <summary>
    /// Класс представляющий сетку для перемещения робота
    /// </summary>
    public class Grid
    {
        #region Открытые свойства

        /// <summary>
        /// Ячейки сетки
        /// </summary>
        public Cell[,] Cells { get; set; }

        /// <summary>
        /// Количество строк в сетке
        /// </summary>
        public int RowCount { get; set; }

        /// <summary>
        /// Количество столбцов в сетке
        /// </summary>
        public int ColumnCount { get; set; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию для инициализатора объектов
        /// </summary>
        public Grid()
        {
            
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="width">ширина сетки</param>
        /// <param name="height">высота сетки</param>
        /// <param name="rowCount">количество столбцов</param>
        /// <param name="columnCount">количество строк</param>
        public Grid(int rowCount, int columnCount)
        {
            Cells = new Cell[rowCount, columnCount];

            RowCount = rowCount;
            ColumnCount = columnCount;
        }

        #endregion
    }
}