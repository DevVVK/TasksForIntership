using RobotObjects.Commands.Base;
using RobotObjects.EmulationEventArgs;
using RobotObjects.Enumerables;
using RobotObjects.Objects;

namespace RobotObjects.Commands
{
    /// <summary>
    /// Класс представляющий команду инициализации эмулятора
    /// </summary>
    public class InitializeEmulationCommand : BaseEmulationCommand<InitializeEmulationEventArgs>
    {
        #region Закрытые поля

        /// <summary>
        /// Количество строк в сетке
        /// </summary>
        private readonly int _rowCountGrid;

        /// <summary>
        /// Количество столбцов в сетке 
        /// </summary>
        private readonly int _columnCountGrid;

        #endregion

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

            _rowCountGrid = grid.RowCount;
            _columnCountGrid = grid.ColumnCount;

            Execute = Initialize;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Метод инициализации сетки
        /// </summary>
        private void Initialize()
        {
            for (var row = 0; row < Grid.RowCount; row++)
            {
                for (var column = 0; column < Grid.ColumnCount; column++)
                {
                    // если первая или последная строка тогда заполнить непроходимыми ячейками
                    if (row == 0 || row == _rowCountGrid - 1)
                    {
                        Grid.Cells[row, column] = new Cell { IsMove = true, Color = ColorCell.Black };
                        continue;
                    }

                    // если первый или последний столбец тогда заполнить непроходимыми ячейками
                    if (column == 0 || column == _columnCountGrid - 1)
                    {
                        Grid.Cells[row, column] = new Cell { IsMove = true, Color = ColorCell.Black };
                        continue;
                    }

                    // заполнить проходимыми ячейками
                    Grid.Cells[row, column] = new Cell { IsMove = true, Color = ColorCell.White };
                }
            }

            OnExecuteEvent(this, new InitializeEmulationEventArgs(Grid.RowCount, Grid.ColumnCount, Robot.Row, Robot.Column));
        }

        #endregion
    }
}