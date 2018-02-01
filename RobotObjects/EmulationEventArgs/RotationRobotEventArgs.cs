using System;
using RobotObjects.Enumerables;

namespace RobotObjects.EmulationEventArgs
{
    /// <summary>
    /// Класс представляющий аргументы события смены направления робота
    /// </summary>
    public class RotationRobotEventArgs : EventArgs
    {
        #region Открытые свойства

        /// <summary>
        /// Направление движения робота
        /// </summary>
        public RouteMove RouteMove { get; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умеолчанию
        /// </summary>
        /// <param name="routeMove">направление движения робота</param>
        public RotationRobotEventArgs(RouteMove routeMove)
        {
            RouteMove = routeMove;
        }

        #endregion
    }
}