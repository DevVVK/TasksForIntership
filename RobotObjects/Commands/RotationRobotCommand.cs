using RobotObjects.Commands.Base;
using RobotObjects.EmulationEventArgs;
using RobotObjects.Enumerables;
using RobotObjects.Objects;

namespace RobotObjects.Commands
{
    /// <summary>
    /// Класс представляющий команду поворота робота в выбранную сторону
    /// </summary>
    public class RotationRobotCommand : BaseEmulationCommand<RotationRobotEventArgs>
    {
        #region Закрытые поля

        /// <summary>
        /// Направление движения робота
        /// </summary>
        private readonly RouteMove _routeRobot; 
        
        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="robot">робот, которому нужно задать направление</param>
        /// <param name="routeRobot">направление движения робота (направо, налево)</param>
        public RotationRobotCommand(Robot robot, RouteMove routeRobot)
        {
            Robot = robot;

            _routeRobot = routeRobot;

            Execute = UpdateRoute;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Метод изменяющий направление движения направление движения
        /// </summary>
        public void UpdateRoute()
        {
            switch (_routeRobot)
            {
                case RouteMove.Right:
                    switch (Robot.RouteMove)
                    {
                        case RouteMove.Right:
                            Robot.RouteMove = RouteMove.Bottom;

                            OnExecuteEvent(this, new RotationRobotEventArgs(Robot.RouteMove));
                            break;

                        case RouteMove.Bottom:
                            Robot.RouteMove = RouteMove.Left;

                            OnExecuteEvent(this, new RotationRobotEventArgs(Robot.RouteMove));
                            break;

                        case RouteMove.Left:
                            Robot.RouteMove = RouteMove.Top;

                            OnExecuteEvent(this, new RotationRobotEventArgs(Robot.RouteMove));
                            break;

                        case RouteMove.Top:
                            Robot.RouteMove = RouteMove.Right;

                            OnExecuteEvent(this, new RotationRobotEventArgs(Robot.RouteMove));
                            break;
                    }
                    break;

                case RouteMove.Left:
                    switch (Robot.RouteMove)
                    {
                        case RouteMove.Right:
                            Robot.RouteMove = RouteMove.Top;

                            OnExecuteEvent(this, new RotationRobotEventArgs(Robot.RouteMove));
                            break;

                        case RouteMove.Top:
                            Robot.RouteMove = RouteMove.Left;

                            OnExecuteEvent(this, new RotationRobotEventArgs(Robot.RouteMove));
                            break;

                        case RouteMove.Left:
                            Robot.RouteMove = RouteMove.Bottom;

                            OnExecuteEvent(this, new RotationRobotEventArgs(Robot.RouteMove));
                            break;

                        case RouteMove.Bottom:
                            Robot.RouteMove = RouteMove.Right;

                            OnExecuteEvent(this, new RotationRobotEventArgs(Robot.RouteMove));
                            break;
                    }
                    break;
            }
        }

        #endregion

    }
}