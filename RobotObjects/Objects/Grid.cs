using RobotObjects.Enumerables;

namespace RobotObjects.Objects
{
    /// <summary>
    /// Класс представляющий сетку для перемещения робота
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// Ячейки сетки
        /// </summary>
        public Cell[,] Cells { get; }

        /// <summary>
        /// Количество строк в сетке
        /// </summary>
        public int RowCount { get; set; }

        /// <summary>
        /// Количество столбцов в сетке
        /// </summary>
        public int ColumnCount { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="width">ширина сетки</param>
        /// <param name="height">высота сетки</param>
        /// <param name="rowCount">количество столбцов</param>
        /// <param name="columnCount">количество строк</param>
        public Grid(int rowCount, int columnCount)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;

            Cells = new Cell[rowCount, columnCount];
            InitializeCells(rowCount, columnCount);
        }

        /// <summary>
        /// Метод инициализации сетки
        /// </summary>
        private void InitializeCells(int rowCount, int columnCount)
        {
            for (var row = 0; row < rowCount; row++)
            {
                for (var column = 0; column < columnCount; column++)
                {
                    // если первая или последная строка тогда заполнить непроходимыми ячейками
                    if (row == 0 || row == rowCount - 1)
                    {
                        Cells[row, column] = new Cell { IsMove = false, Color = ColorCell.Black };
                        continue;
                    }

                    // если первый или последний столбец тогда заполнить непроходимыми ячейками
                    if (column == 0 || column == columnCount - 1)
                    {
                        Cells[row, column] = new Cell { IsMove = false, Color = ColorCell.Black };
                        continue;
                    }

                    // заполнить проходимыми ячейками
                    Cells[row, column] = new Cell { IsMove = true, Color = ColorCell.White };
                }
            }
        }
    }
}