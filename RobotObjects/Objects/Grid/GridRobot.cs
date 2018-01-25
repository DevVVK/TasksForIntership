using System.Collections.Generic;
using RobotObjects.Objects.Base;

namespace RobotObjects.Objects.Grid
{
    /// <summary>
    /// Класс представляющий сетку для перемещения робота
    /// </summary>
    public class GridRobot : BaseRobot
    {
        #region Открытые свойства

        /// <summary>
        /// Ячейки сетки
        /// </summary>
        public List<List<CellRobot>> Cells { get; set; }

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
        public GridRobot()
        {
            
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="width">ширина сетки</param>
        /// <param name="height">высота сетки</param>
        /// <param name="rowCount">количество столбцов</param>
        /// <param name="columnCount">количество строк</param>
        public GridRobot(double width, double height, int rowCount, int columnCount) : base(width, height)
        {
            Cells = new List<List<CellRobot>>();

            RowCount = rowCount;
            ColumnCount = columnCount;
        }

        #endregion
    }
}