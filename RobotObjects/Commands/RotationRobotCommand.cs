using System;
using RobotObjects.Commands.Base;
using RobotObjects.Enumerables;
using RobotObjects.Objects;

namespace RobotObjects.Commands
{
    /// <summary>
    /// Класс представляющий команду поворота робота в выбранную сторону
    /// </summary>
    public class RotationRobotCommand : BaseRobotCommand 
    {
        /// <summary>
        /// Направление движения робота
        /// </summary>
        private readonly RouteMove _routeRobot; 

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

        /// <summary>
        /// Метод изменяющий направление движения направление движения
        /// </summary>
        private void UpdateRoute()
        {
            switch (_routeRobot)
            {
                case RouteMove.Right:
                    switch (Robot.RouteMove)
                    {
                        case RouteMove.Right: Update(Robot, RouteMove.Bottom); break;
                        case RouteMove.Bottom: Update(Robot, RouteMove.Left); break;
                        case RouteMove.Left: Update(Robot, RouteMove.Top); break;
                        case RouteMove.Top: Update(Robot, RouteMove.Right); break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    break;

                case RouteMove.Left:
                    switch (Robot.RouteMove)
                    {
                        case RouteMove.Right: Update(Robot, RouteMove.Top); break;
                        case RouteMove.Top: Update(Robot, RouteMove.Left); break;
                        case RouteMove.Left: Update(Robot, RouteMove.Bottom); break;
                        case RouteMove.Bottom: Update(Robot, RouteMove.Right); break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Метод для изменения направления движения робота и вызова обработчика события изменения направления робота
        /// </summary>
        /// <param name="robot">робот</param>
        /// <param name="route">направление</param>
        private void Update(Robot robot, RouteMove route) => robot.RouteMove = route;
    }
}