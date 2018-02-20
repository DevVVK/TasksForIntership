using System;
using RobotObjects.Objects;

namespace RobotObjects.Commands.Base
{
    /// <summary>
    /// Базовый класс команд эмулятора
    /// </summary>
    public class BaseRobotCommand
    {
        /// <summary>
        /// Идентификатор команды
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор следующей команды
        /// </summary>
        public int NextNumberCommand { get; set; }

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

        /// <summary>
        /// Метод выполнения команды
        /// </summary>
        public void ExecuteMethod() => Execute?.Invoke();
    }
} 