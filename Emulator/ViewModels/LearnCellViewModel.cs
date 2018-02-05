using System.Collections.ObjectModel;
using Emulator.Commands.Base;
using Emulator.Mappers;
using Emulator.Models;
using Emulator.ViewModels.Base;
using Emulator.ViewModels.Helpers;

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

        #region Для команд

        /// <summary>
        /// Поле для добавления команды изучения ячейки
        /// </summary>
        private BaseCommandRelay _addLearnCellCommand;

        #endregion 

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
        public ObservableCollection<int> NumbersCommandIfCellWhiteSource { get; set; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// <param name="commandList">список команд выполняемых роботом</param>
        /// </summary>
        public LearnCellViewModel(ObservableCollection<CommandModel> commandList)
        {
            _commandList = commandList;

            NumbersCommandIfCellBlackSource = new ObservableCollection<int>();
            RowGenerator.Initialize(NumbersCommandIfCellBlackSource, 0, 100, 1);

            NumbersCommandIfCellWhiteSource = new ObservableCollection<int>();
            RowGenerator.Initialize(NumbersCommandIfCellWhiteSource, 0, 100, 1);
        }

        #endregion

        #region Команды

        /// <summary>
        /// Команда изучения цвета заливки ячейки, на которой находится робот
        /// </summary>
        public BaseCommandRelay LearnCellCommand =>
            _addLearnCellCommand ?? (_addLearnCellCommand = new BaseCommandRelay(AddLearnCellCommandInList));

        #endregion

        #region Методы 

        /// <summary>
        /// Метод добавляющий команду изучения ячейки в список команд
        /// </summary>
        private void AddLearnCellCommandInList()
        {
            var learnCellCommandModel = new LearnCellCommandModel
            {
                Id = _commandList.Count,
                CommandIdIfCellColorBlack = NumberCommandIfCellBlack,
                CommandIdIfCellColorWhite = NumberCommandIfCellWhite
            };

            _commandList.Add(ListModelMapper.GetCommand(learnCellCommandModel));
        }

        #endregion
    }
}