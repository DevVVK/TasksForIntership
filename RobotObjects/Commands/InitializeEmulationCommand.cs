using RobotObjects.Commands.Base;
using RobotObjects.Enumerables;
using RobotObjects.Objects;

namespace RobotObjects.Commands
{
    /// <summary>
    /// Класс представляющий команду инициализации эмулятора
    /// </summary>
    public class InitializeEmulationCommand : BaseRobotCommand
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="grid">сетка, в которой должен перемещаться робот</param>
        /// <param name="robot">робот, который должен перемещаться в сетке</param>
        public InitializeEmulationCommand(Grid grid, Robot robot)
        {
            Grid = grid;
            Robot = robot;
            Initialize(grid.RowCount, grid.ColumnCount);
        }

        #endregion

        #region Методы

        /// <summary>
        /// Метод инициализации сетки
        /// </summary>
        private void Initialize(int rowCount, int columnCount)
        {
            for (var row = 0; row < rowCount; row++)
            {
                for (var column = 0; column < columnCount; column++)
                {
                    // если первая или последная строка тогда заполнить непроходимыми ячейками
                    if (row == 0 || row == rowCount - 1)
                    {
                        Grid.Cells[row, column] = new Cell { IsMove = false, Color = ColorCell.Black };
                        continue;
                    }

                    // если первый или последний столбец тогда заполнить непроходимыми ячейками
                    if (column == 0 || column == columnCount - 1)
                    {
                        Grid.Cells[row, column] = new Cell { IsMove = false, Color = ColorCell.Black };
                        continue;
                    }

                    // заполнить проходимыми ячейками
                    Grid.Cells[row, column] = new Cell { IsMove = true, Color = ColorCell.White };
                }
            }
        }

        #endregion
    }
}