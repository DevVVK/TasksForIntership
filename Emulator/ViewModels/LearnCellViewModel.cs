using System.Collections.ObjectModel;
using System.Windows.Input;
using Emulator.Commands.Base;
using Emulator.Models;
using Emulator.ViewModels.Base;

namespace Emulator.ViewModels
{
    /// <summary>
    /// Класс представляющий модель-представления окна команды изучения ячейки на предмет цвета
    /// </summary>
    public class LearnCellViewModel : BaseViewModel
    {
        #region Закрытые свойства

        /// <summary>
        /// Список команд выполняемых роботом
        /// </summary>
        private ObservableCollection<CommandModel> _commandList;

        #endregion

        #region Открытые свойства

        /// <summary>
        /// Номер команды если цвет ячейки черный
        /// </summary>
        public int NumberCommandIfCellBlack { get; set; }

        /// <summary>
        /// Номер команды если цвет ячейки белый
        /// </summary>
        public int NumberCommandIfCellWhite { get; set; }

        /// <summary>
        /// Источник для выбора номера команды если цвет ячейки черный
        /// </summary>
        public ObservableCollection<int> NumbersCommandIfCellBlackSource { get; set; }

        /// <summary>
        /// Источник для выбора номера команды если цвет ячейки белый
        /// </summary>
        public ObservableCollection<int> NumberCommandIfCellWhiteSource { get; set; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// <param name="commandList">список команд выполняемых роботом</param>
        /// </summary>
        public LearnCellViewModel(ObservableCollection<CommandModel> commandList)
        {
            _commandList = commandList;
        }

        #endregion

        #region Команды

        /// <summary>
        /// Команда изучения цвета заливки ячейки, на которой находится робот
        /// </summary>
        public BaseCommandRelay LearnCellCommand { get; }

        #endregion
    }
}