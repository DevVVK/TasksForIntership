using RobotObjects.Objects.Base;
using RobotObjects.Objects.Enumerables;

namespace RobotObjects.Objects.Commands
{
    /// <summary>
    /// Класс представляющий команду поворота робота в выбранную сторону
    /// </summary>
    public class RotationCommand : BaseRobotCommand
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
        public RotationCommand(Robot robot, RouteMove routeRobot)
        {
            //поля
            Robot = robot;
            _routeRobot = routeRobot;

            //методы
            ExecuteMethod = UpdateRoute;

            //добавить данную команды в список команд
            CommandList.Add(this);
        }

        #endregion

        #region Методы

        /// <summary>
        /// Изменить направление движения
        /// </summary>
        public void UpdateRoute()
        {
            Robot.RouteMove = _routeRobot;
        }

        #endregion

    }
}