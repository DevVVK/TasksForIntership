using System;
using System.Windows.Input;

namespace Emulator.Commands.Base
{
    /// <summary>
    /// Базовый класс команд
    /// </summary>
    public class BaseCommandRelay : ICommand
    {
        #region Свойства
        
        /// <summary>
        /// Делегат принимающий обработчик команды
        /// </summary>
        private readonly Action<object> _execute;

        /// <summary>
        /// Делегат принимающий обработчик проверяющий условие выполнения команды
        /// </summary>
        private readonly Func<object, bool> _canExecute;

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="execute">команда</param>
        /// <param name="canExecute">условие выполнения</param>
        public BaseCommandRelay(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Проверка возможности выполнения команды
        /// </summary>
        /// <param name="parameter">параметр выполнения</param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        /// <summary>
        /// Запускает обработчик команды
        /// </summary>
        /// <param name="parameter">параметр выполнения</param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        /// <summary>
        /// Обработчик регистрации команд см. <see cref="CommandManager"/>
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        
        #endregion
    }
}