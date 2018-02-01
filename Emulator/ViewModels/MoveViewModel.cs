using System.Collections.Generic;
using System.Collections.ObjectModel;
using Emulator.Commands.Base;
using Emulator.Mappers;
using Emulator.Models;
using Emulator.ViewModels.Base;

namespace Emulator.ViewModels
{
    /// <summary>
    /// Класс представляющий модель-представления для окна команды движения
    /// </summary>
    public class MoveViewModel : BaseViewModel
    {
        #region Закрытые поля 

        /// <summary>
        /// Список выполняемых команд
        /// </summary>
        private readonly ObservableCollection<CommandModel> _commandList;

        //TODO: реализовать выбор номера выполнения следующей команды
        /// <summary>
        /// Список номеров команд для выбора номера следующей команды
        /// </summary>
        private readonly ObservableCollection<int> _nextCommandSource;

        #region Для команд

        /// <summary>
        /// Поле для команды добавления команды движения в список
        /// </summary>
        private BaseCommandRelay _addMoveRobotCommand;

        #endregion

        #endregion

        #region Открытые свойства

        /// <summary>
        /// Номер следующей команды
        /// </summary>
        public int NextCommandNumber { get; set; }

        /// <summary>
        /// Список номеров команд для выбора номера следующей команды
        /// </summary>
        public ObservableCollection<int> NextCommandSource { get; set; }

        /// <summary>
        /// Количество клеток, на которое нужно переместить робота
        /// </summary>
        public int CellMoveCount { get; set; }

        /// <summary>
        /// Источник для выбора количества клеток, на которое может переместиться робот
        /// </summary>
        public List<int> CellMoveSource { get; set; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="commandList">список выполняемых команд</param>
        public MoveViewModel(ObservableCollection<CommandModel> commandList)
        {
            _commandList = commandList;
            CellMoveSource = new List<int>(); InitializeSource(CellMoveSource, 0, 100);

            NextCommandNumber = commandList.Count;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Метод для инициализации источников
        /// </summary>
        /// <param name="recipient">приемник</param>
        /// <param name="begin">начало интервала</param>
        /// <param name="end">конец интервала</param>
        private void InitializeSource(ICollection<int> recipient, int begin, int end)
        {
            recipient?.Clear();

            for (var item = begin; item < end; item++) recipient?.Add(item);
        }

        #endregion

        #region  Команды

        /// <summary>
        /// Команда перемещения робота
        /// </summary>
        public BaseCommandRelay AddMoveRobotCommand => 
               _addMoveRobotCommand ?? (_addMoveRobotCommand = new BaseCommandRelay(AddMoveRobotCommandMethod));

        #region Методы для команд

        /// <summary>
        /// Метод добавляющий команду движения робота в список команд
        /// </summary>
        private void AddMoveRobotCommandMethod()
        {
            var moveRobotModel = new MoveCommandModel
            {
                Id = _commandList.Count,
                CellCount = CellMoveCount,
                //TODO: переделать функцию выбора следующей команды
                NextCommandNumber = _commandList.Count + 1
            };

            _commandList.Add(ModelMapper.GetCommand(moveRobotModel));
        }

        #endregion 

        #endregion
    }
}