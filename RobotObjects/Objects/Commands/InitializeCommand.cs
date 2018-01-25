using System.Collections.Generic;
using RobotObjects.Objects.Base;
using RobotObjects.Objects.Enumerables;
using RobotObjects.Objects.Grid;

namespace RobotObjects.Objects.Commands
{
    /// <summary>
    /// Класс представляющий команду инициализации эмулятора
    /// </summary>
    public class InitializeCommand : BaseRobotCommand
    {
        #region Закрытые поля

        /// <summary>
        /// Количество строк в сетке
        /// </summary>
        private readonly int _rowCount;

        /// <summary>
        /// Количество столбцов в сетке
        /// </summary>
        private readonly int _columnCount;

        /// <summary>
        /// Ширина сетки
        /// </summary>
        private readonly double _widthGrid;

        /// <summary>
        /// Высота сетки
        /// </summary>
        private readonly double _heightGrid;

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="gridRobot">сетка, которую нужно заполнить ячейками</param>
        /// <param name="robot">робот, которого нужно установить в указанную ячейку</param>
        public InitializeCommand(GridRobot gridRobot, Robot robot)
        {
            GridRobot = gridRobot;
            Robot = robot;

            _widthGrid = gridRobot.Width;
            _heightGrid = gridRobot.Height;
            _rowCount = gridRobot.RowCount;
            _columnCount = gridRobot.ColumnCount;

            ExecuteMethod = InitializationGridRobot;
        }
        
        #endregion

        #region Методы

        /// <summary>
        /// Метод заполняющий сетку ячейками
        /// </summary>
        private void InitializationGridRobot()
        {
            var sizeCell = _widthGrid / _columnCount - 2.0;

            for (var row = 0; row < _rowCount; row++)
            {
                var line = new List<CellRobot>();

                for (var column = 0; column < _columnCount; column++)
                {
                    // если первая или последная строка тогда заполнить непроходимыми ячейками
                    if (row == 0 || row == _rowCount - 1)
                    {
                        line.Add(new CellRobot { Width = sizeCell, Height = sizeCell, IsMove = true, Color = ColorCell.Black });
                        continue;
                    }

                    // если первый или последний столбец тогда заполнить непроходимыми ячейками
                    if (column == 0 || column == _columnCount - 1)
                    {
                        line.Add(new CellRobot { Width = sizeCell, Height = sizeCell, IsMove = true, Color = ColorCell.Black });
                        continue;
                    }

                    // заполнить проходимыми ячейками
                    line.Add(new CellRobot { Width = sizeCell, Height = sizeCell, IsMove = true, Color = ColorCell.White });
                }

                GridRobot.Cells.Add(line);
            }
        }
        
        #endregion
    }
}