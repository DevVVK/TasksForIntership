using RobotObjects.Commands.Base;
using RobotObjects.EmulationEventArgs;
using RobotObjects.Enumerables;
using RobotObjects.Objects;

namespace RobotObjects.Commands
{
    /// <summary>
    /// Класс представляющий  движения робота на выбранное количество клеток
    /// </summary>
    public class MoveRobotCommand : BaseEmulationCommand<MoveRobotEventArgs>
    {
        #region Открытые свойства



        #endregion

        #region Закрытые поля

        /// <summary>
        /// Поле для хранения количества клеток, на которое нужно переместить робота
        /// </summary>
        private readonly int _cellCount;

        /// <summary>
        /// Направление движения робота
        /// </summary>
        private readonly RouteMove _routeMoveRobot;

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="grid">сетка, по которой перемещается робот</param>
        /// <param name="robot">робот, которого нужно переместить</param>
        /// <param name="cellCount">количество клеток, на которое нужно переместить робота</param>
        public MoveRobotCommand(Grid grid, Robot robot, int cellCount)
        {
            Grid = grid;
            Robot = robot;
            _cellCount = cellCount;
            _routeMoveRobot = Robot.RouteMove;
            Execute = Move;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Команда движения на указанное количество клеток
        /// </summary>
        private void Move()
        {
            switch (_routeMoveRobot)
            {
                case RouteMove.Right:
                    for (var index = 0; index < _cellCount; index++)
                    {
                        Robot.Column++;
                        OnExecuteEvent(this, new MoveRobotEventArgs(Robot.Row, Robot.Column));
                    }

                    break;

                case RouteMove.Top:
                    for (var index = 0; index < _cellCount; index++)
                    {
                        Robot.Row--;
                        OnExecuteEvent(this, new MoveRobotEventArgs(Robot.Row, Robot.Column));
                    }

                    break;

                case RouteMove.Left:
                    for (var index = 0; index < _cellCount; index++)
                    {
                        Robot.Column--;
                        OnExecuteEvent(this, new MoveRobotEventArgs(Robot.Row, Robot.Column));
                    }

                    break;

                case RouteMove.Bottom:
                    for (var index = 0; index < _cellCount; index++)
                    {
                        Robot.Row++;
                        OnExecuteEvent(this, new MoveRobotEventArgs(Robot.Row, Robot.Column));
                    }

                    break;
            }
        }

        #endregion
    }
}