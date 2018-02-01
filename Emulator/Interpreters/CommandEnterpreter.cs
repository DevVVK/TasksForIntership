using System.Collections.Generic;
using System.Collections.ObjectModel;
using Emulator.Commands.Base;
using Emulator.Models;

namespace Emulator.Interpreters
{
    /// <summary>
    /// Класс представляющий интерпретатор команд
    /// </summary>
    public class CommandEnterpreter
    {
        #region Закрытые поля 

        /// <summary>
        /// Список выполняемых команд
        /// </summary>
        private readonly ObservableCollection<CommandModel> _commandList;

        /// <summary>
        /// Список отображенных в объеткы команд
        /// </summary>
        private List<BaseCommandRelay> _executeList;

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="commandList">Список команд для отображения в объеты команд</param>
        public CommandEnterpreter(ObservableCollection<CommandModel> commandList)
        {
            _commandList = commandList;
            _executeList = new List<BaseCommandRelay>();
        }

        #endregion

        #region Методы


        #endregion
    }
}