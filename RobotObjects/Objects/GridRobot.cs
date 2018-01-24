using System.Collections.Generic;
using System.Linq;
using RobotObjects.Objects.Base;

namespace RobotObjects.Objects
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
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="width">ширина сетки</param>
        /// <param name="height">высота сетки</param>
        public GridRobot(double width, double height) : base(width, height)
        {
            Cells = new List<List<CellRobot>>();

            RowCount = Cells.Count;
            ColumnCount = Cells[0].Count;
        }

        #endregion
    }
}