using System;
using RobotObjects.Objects;

namespace RobotObjects.Commands.Base
{
    /// <summary>
    /// Базовый класс команд эмулятора
    /// </summary>
    public class BaseRobotCommand
    {
        #region Защищенные свойства

        /// <summary>
        /// Ссылка на вызываемый метод команды
        /// </summary>
        protected Action Execute { get; set; }
         
        /// <summary>
        /// Робот-исполнитель
        /// </summary>
        protected Robot Robot { get; set; }

        /// <summary>
        /// Сетка, в которой перемещается робот
        /// </summary>
        protected Grid Grid { get; set; }

        #endregion

        #region Методы 

        /// <summary>
        /// Метод выполнения команды
        /// </summary>
        public void ExecuteMethod() => Execute?.Invoke();
     
        #endregion
    }
} 