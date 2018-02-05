using System;

namespace RobotObjects.Commands.Base
{
    /// <summary>
    /// Базовый класс комманд для вызова события выполнения команд роботом 
    /// </summary>
    /// <typeparam name="TArgs">тип аргумета события</typeparam>
    public class BaseEmulationCommand<TArgs> : BaseRobotCommand where TArgs : EventArgs 
    {
        /// <summary>
        /// Событие для обновления объектов эмулятора
        /// </summary>
        private EventHandler _executeEvent;

        /// <summary>
        /// Объект заглушка для взаимной блокировки потоков
        /// </summary>
        private readonly object _locker = new object();

        /// <summary>
        /// Событие для обновления объектов эмулятора
        /// </summary>
        public event EventHandler ExecuteEvent
        {
            add
            {
                lock (_locker)
                {
                    _executeEvent += value;
                }
            }
            remove
            {
                lock(_locker)
                {
                    if (value != null)
                        _executeEvent -= value;
                    
                }
            }
        }

        /// <summary>
        ///  Метод вызывающий обработчик события
        /// </summary>
        protected virtual void OnExecuteEvent(object sender, TArgs e) => _executeEvent?.Invoke(sender, e);
    }
}