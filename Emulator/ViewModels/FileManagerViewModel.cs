using System.Collections.ObjectModel;
using Emulator.Commands.Base;
using Emulator.Models;
using Emulator.ViewModels.Base;

namespace Emulator.ViewModels
{
    /// <summary>
    /// Класс представляющий модель-представления 
    /// </summary>
    public class FileManagerViewModel : BaseViewModel
    {
        #region Закрытые поля 

        /// <summary>
        /// Список команд выполняемых роботом 
        /// </summary>
        private ObservableCollection<CommandModel> _commandList;

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="commandList">список выполняемых роботом команд</param>
        public FileManagerViewModel(ObservableCollection<CommandModel> commandList)
        {
            _commandList = commandList;
        }

        #endregion

        #region Команды 

        /// <summary>
        /// Команда сохраняющая алгоритм в файл
        /// </summary>
        public BaseCommandRelay SaveToFile { get; }

        /// <summary>
        /// Команда окрывающия алгоритм из файла
        /// </summary>
        public BaseCommandRelay OpenFile { get; }

        #endregion
    }
}