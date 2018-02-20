using System;
using RobotObjects.Commands.Base;
using RobotObjects.Enumerables;
using RobotObjects.Exceptions;
using RobotObjects.Objects;

namespace RobotObjects.Commands
{
    /// <summary>
    /// Класс представляющий  движения робота на выбранное количество клеток
    /// </summary>
    public class MoveRobotCommand : BaseRobotCommand
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="grid">сетка, по которой перемещается робот</param>
        /// <param name="robot">робот, которого нужно переместить</param>
        /// <param name="cellCount">количество клеток, на которое нужно переместить робота</param>
        public MoveRobotCommand(Grid grid, Robot robot)
        {
            Grid = grid;
            Robot = robot;
            _cellCount = cellCount;

            Execute = Move;
        }

        /// <summary>
        /// Метод для перемещения робота по указанному направлению
        /// </summary>
        private void Move()
        {
            switch (Robot.RouteMove)
            {
                case RouteMove.Right: UpdateMove(Grid.Cells, Robot, () => Robot.Column++); break;
                case RouteMove.Top: UpdateMove(Grid.Cells, Robot, () => Robot.Row--); break;
                case RouteMove.Left: UpdateMove(Grid.Cells, Robot, () => Robot.Column--); break;
                case RouteMove.Bottom: UpdateMove(Grid.Cells, Robot, () => Robot.Row++); break;
            }
        }

        /// <summary>
        /// Метод для передвижения робота
        /// </summary>
        /// <param name="cells">сетка</param>
        /// <param name="robot">робот</param>
        /// <param name="cellCount">количество ячеек, на которое нужно переместить робота</param>
        /// <param name="iteration">метод изменения индекса строки или столбца</param>
        private void UpdateMove(Cell[,] cells, Robot robot, Action iteration)
        {
            CheckCellOnMove(cells, robot);
            iteration?.Invoke();
        }

        /// <summary>
        /// Метод для проверки проходимости ячейки по указанному напрпавлению 
        /// </summary>
        /// <param name="cells">сетка</param>
        /// <param name="robot">робот</param>
        private void CheckCellOnMove(Cell[,] cells, Robot robot)
        {
            switch (robot.RouteMove)
            {
                case RouteMove.Right: CheckInException(cells, robot.Row, robot.Column + 1); break;
                case RouteMove.Left: CheckInException(cells, robot.Row, robot.Column - 1); break;
                case RouteMove.Top: CheckInException(cells, robot.Row - 1, robot.Column); break;
                case RouteMove.Bottom: CheckInException(cells, robot.Row + 1, robot.Column); break;
            }
        }

        /// <summary>
        /// Метод для проверки проходимости ячейки, если ячейка на проходимя, 
        /// то выбрасывается искючение см. <see cref="NotIsMoveInCellException"/> 
        /// </summary>
        /// <param name="cells">сетка</param>
        /// <param name="row">индекс строки ячейкистрока</param>
        /// <param name="column">индекс столбца ячейки</param>
        private void CheckInException(Cell[,] cells, int row, int column)
        {
            if (!cells[row, column].IsMove) throw new NotIsMoveInCellException();
        }
    }
}