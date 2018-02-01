using System.Collections.ObjectModel;
using Emulator.Commands.Base;
using Emulator.Models;
using Emulator.ViewModels.Base;

namespace Emulator.ViewModels
{
    /// <summary>
    /// Класс представляющий модель-представления части отвечающей за выполнение списка команд
    /// </summary>
    public class CommandListManagerViewModel : BaseViewModel
    {
        #region Закрытые свойства

        /// <summary>
        /// Список команд выполняемых роботом
        /// </summary>
        private ObservableCollection<CommandModel> _commandList;

        #endregion

        #region Конструкторы 

        /// <summary>
        /// Конструктор по умолчению
        /// </summary>
        /// <param name="commandList">спико комманд вы полняемых роботом</param>
        public CommandListManagerViewModel(ObservableCollection<CommandModel> commandList)
        {
            _commandList = commandList;
        }

        #endregion

        #region Команды

        /// <summary>
        /// Команда запускающая исполнение список команд
        /// </summary>
        public BaseCommandRelay StartEmulation { get; }

        /// <summary>
        /// Команда запускающая пошаговое выполнение списка команд
        /// </summary>
        public BaseCommandRelay StartStepEmulation { get; }

        /// <summary>
        /// Команда очищающая список команд
        /// </summary>
        public BaseCommandRelay ClearListCommand { get; }

        #endregion
    }
}