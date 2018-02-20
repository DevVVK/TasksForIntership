using RobotObjects.Commands.Base;
using RobotObjects.Enumerables;
using RobotObjects.Objects;

namespace RobotObjects.Commands
{
    /// <summary>
    /// Класс представляющий команду заливки ячейки выбранным цветом
    /// </summary>
    public class PouringCellCommand : BaseRobotCommand
    {
        /// <summary>
        /// Цвет заливки ячейки, в которой находится робот
        /// </summary>
        private readonly ColorCell _pouringColor;

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

        /// <summary>
        /// Метод изменяющий цвет ячейки, на которой находится робот
        /// </summary>
        private void PouringCell()
        {
            //извлечение ячейки на которой стоит робот
            var cell = Grid.Cells[Robot.Row, Robot.Column];

            if (cell == null) return;
            
            //изменение цвета
            cell.Color = _pouringColor;
        }
    }
}