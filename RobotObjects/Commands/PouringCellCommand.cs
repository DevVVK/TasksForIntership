using RobotObjects.Commands.Base;
using RobotObjects.EmulationEventArgs;
using RobotObjects.Enumerables;
using RobotObjects.Objects;

namespace RobotObjects.Commands
{
    /// <summary>
    /// Класс представляющий команду заливки ячейки выбранным цветом
    /// </summary>
    public class PouringCellCommand : BaseEmulationCommand<PouringCellEventArgs>
    {
        #region Закрытые поля

        /// <summary>
        /// Цвет заливки ячейки, в которой находится робот
        /// </summary>
        private readonly ColorCell _pouringColor;

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="grid">сетка, по которой передвигается робот</param>
        /// <param name="robot">робот</param>
        /// <param name="pouringColor">цвет заливки ячейки, в которой находится робот</param>
        public PouringCellCommand(Grid grid, Robot robot, ColorCell pouringColor)
        {
            Grid = grid;
            Robot = robot;

            _pouringColor = pouringColor;

            Execute = PouringCell;
        }

        #endregion

        #region Методы 

        /// <summary>
        /// Метод изменяющий цвет ячейки, на которой находится робот
        /// </summary>
        private void PouringCell()
        {
            //извлечение ячейки на которой стоит робот
            var cell = Grid.Cells[Robot.Row, Robot.Column];

            //изменение цвета
            if (cell == null) return; cell.Color = _pouringColor;

            OnExecuteEvent(this, new PouringCellEventArgs(Robot.Row, Robot.Column, cell.Color));
        }

        #endregion
    }
}