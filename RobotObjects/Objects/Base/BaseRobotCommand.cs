using System;
using System.Collections.Generic;
using RobotObjects.Objects.Grid;

namespace RobotObjects.Objects.Base
{
    /// <summary>
    /// Базовый класс команд, которые должен выполнить робот
    /// </summary>
    public class BaseRobotCommand
    {
        #region Открытые свойства

        #endregion

        #region Поля для наследников

        /// <summary>
        /// Сетка для передвижения робота
        /// </summary>
        protected GridRobot GridRobot;

        /// <summary>
        /// Робот, с которым нужно выполнить определенную команду
        /// </summary>
        protected Robot Robot;

        /// <summary>
        /// Делегат для метода выполнения команды
        /// </summary>
        protected Action ExecuteMethod;

        /// <summary>
        /// Делегат для метода проверки возможности выполнения команды
        /// </summary>
        protected Func<bool> CanExecuteMethod;

        /// <summary>
        /// Список команд для повторного выполнения команд
        /// </summary>
        protected static List<BaseRobotCommand> CommandList = new List<BaseRobotCommand>();

        #endregion

        #region Методы

        /// <summary>
        /// Метод проверяющий возможность выполнения команды
        /// </summary>
        /// <returns></returns>
        public bool CanExecute()
        {
            return ExecuteMethod != null && CanExecuteMethod();
        }

        /// <summary>
        /// Методы выполнения команды
        /// </summary>
        public void Execute()
        {
            if (CanExecute()) ExecuteMethod();
        }

        #endregion
    }
}