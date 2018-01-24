using System.Collections.Generic;
using RobotObjects.Objects.Base;
using RobotObjects.Objects.Enumerables;

namespace RobotObjects.Objects
{
    /// <inheritdoc />
    /// <summary>
    /// Класс для построения сетки 
    /// </summary>
    public class GridBuilder : BaseRobot
    {
        #region Закрытые свойства

        /// <summary>
        /// Количество столбцов
        /// </summary>
        private readonly double _columnCount;

        /// <summary>
        /// Количество строк
        /// </summary>
        private readonly double _rowCount;

        /// <summary>
        /// Сетка для передвижения робота
        /// </summary>
        private readonly GridRobot _gridRobot;

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="width">ширина сетки</param>
        /// <param name="height">высота сетки</param>
        /// <param name="columnCount">количество столбцов</param>
        /// <param name="rowCount">количество строк</param>
        public GridBuilder(double width, double height, int columnCount, int rowCount) : base(width, height)
        {
            _columnCount = columnCount;
            _rowCount = rowCount;
            _gridRobot = new GridRobot(width, height);
        }

        /// <summary>
        /// Конструктор для созданного объекта класса см. <see cref="GridRobot"/>
        /// </summary>
        /// <param name="gridRobot">сетка которую нужно заполнить ячейками</param>
        /// <param name="columnCount">количество столбцов</param>
        /// <param name="rowCount">количество строк</param>
        public GridBuilder(GridRobot gridRobot, int columnCount, int rowCount) : base(gridRobot.Width, gridRobot.Height)
        {
            _columnCount = columnCount;
            _rowCount = rowCount;
            _gridRobot = gridRobot;
        }

        #endregion

        #region Методы
        
        /// <summary>
        /// Метод построения сетки по заданному размеру
        /// </summary>
        /// <returns>список ячеек</returns>
        public GridRobot GetBuildGridRobot()
        {
            for (var row = 0; row < _rowCount; row++)
            {
                var line = new List<CellRobot>();

                for (var column = 0; column < _columnCount; column++)
                {
                    // если первая или последная строка тогда заполнить непроходимыми ячейками
                    if (row == 0 || row == _rowCount - 1)
                    {
                        line.Add(new CellRobot { Width = Width / _columnCount - 2.0, Height = Width, IsMove = true, Color = ColorCell.Black});
                        continue;
                    }

                    // если первый или последний столбец тогда заполнить непроходимыми ячейками
                    if (column == 0 || column == _columnCount - 1)
                    {
                        line.Add(new CellRobot { Width = Width / _columnCount - 2.0, Height = Width, IsMove = true, Color = ColorCell.Black});
                        continue;
                    }

                    // заполнить проходимыми ячейками
                    line.Add(new CellRobot { Width = Width / _columnCount - 2.0, Height = Width, IsMove = true, Color = ColorCell.White});
                }

                _gridRobot.Cells.Add(line);
            }

            return _gridRobot;
        }

        #endregion

    }
}