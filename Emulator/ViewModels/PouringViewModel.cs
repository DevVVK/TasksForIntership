using System.Collections.ObjectModel;
using Emulator.Commands.Base;
using Emulator.Mappers;
using Emulator.Models;
using Emulator.ViewModels.Base;
using RobotObjects.Enumerables;

namespace Emulator.ViewModels
{
    /// <summary>
    /// Класс представляющий модель-представления для окна команды заливки ячейки
    /// </summary>
    public class PouringViewModel : BaseViewModel
    {
        #region Закрытые поля 

        /// <summary>
        /// Список команд
        /// </summary>
        private readonly ObservableCollection<CommandModel> _commandList;

        #region Для команд

        /// <summary>
        /// Поле для команды добавления в список команды заливки ячейки
        /// </summary>
        private BaseCommandRelay _addPourungCommand;

        #endregion

        #endregion

        #region Свойства для команды заливки ячейки, на которой находится робот

        /// <summary>
        /// Цвет заливки ячейки
        /// </summary>
        public ColorCell Color { get; set; }

        /// <summary>
        /// Источник для выбора цвета заливки ячейки
        /// </summary>
        public ObservableCollection<string> ColorVaiableSource { get; set; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="commandList"></param>
        public PouringViewModel(ObservableCollection<CommandModel> commandList)
        {
            _commandList = commandList;
        }

        #endregion

        #region Команды 

        /// <summary>
        /// Команда заливки ячейки где находится робот
        /// </summary>
        public BaseCommandRelay PouringCommand =>
            _addPourungCommand ?? (_addPourungCommand = new BaseCommandRelay(AddPouringCommandInList));

        #region Методы для команд

        /// <summary>
        /// Метод добавления команды заливки ячейки выбранным цветом
        /// </summary>
        private void AddPouringCommandInList()
        {
            var pouringCommandModel = new PouringCellCommandModel
            {
                Id = _commandList.Count,
                CellColor = Color,
                NextCommandId = _commandList.Count + 1
            };

            _commandList.Add(ListModelMapper.GetCommand(pouringCommandModel));
        }

        #endregion 

        #endregion
    }
}