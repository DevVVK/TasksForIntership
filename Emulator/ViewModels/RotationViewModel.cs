using System.Collections.ObjectModel;
using Emulator.Commands.Base;
using Emulator.Mappers;
using Emulator.Models;
using Emulator.ViewModels.Base;
using RobotObjects.Enumerables;

namespace Emulator.ViewModels
{
    /// <summary>
    /// Класс представляющий модель-представления управления командой поворота робота в указанную сторону
    /// </summary>
    public class RotationViewModel : BaseViewModel
    {
        #region Закрытые поля 

        /// <summary>
        /// Список команд выполняемых роботом
        /// </summary>
        private ObservableCollection<CommandModel> _commandList;

        #region  Для команд

        /// <summary>
        /// Поля для команды добавления команды поворота в список команд
        /// </summary>
        private BaseCommandRelay _addRotationCommand;

        #endregion

        #endregion

        #region Открытые свойства

        /// <summary>
        /// Направление движения робота
        /// </summary>
        public RouteMove Route { get; set; }

        /// <summary>
        /// Источник для выбора направления движения робота
        /// </summary>
        public ObservableCollection<string> RouteMoveSource { get; set; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="commandList">список команд выполняемых роботом</param>
        public RotationViewModel(ObservableCollection<CommandModel> commandList)
        {
            _commandList = commandList;
        }

        #endregion

        #region Команды 

        /// <summary>
        /// Команда поворота робота 
        /// </summary>
        public BaseCommandRelay AddRotationCommand =>
            _addRotationCommand ?? (_addRotationCommand = new BaseCommandRelay(AddRotationCommandInList));

        #region Методы для команд

        /// <summary>
        /// Метод добавления команды поворота в список
        /// </summary>
        private void AddRotationCommandInList()
        {
            var rotationRobotModel = new RotationCommandModel
            {
                Id = _commandList.Count,
                Route = Route,
                NextCommandId = _commandList.Count + 1
            };

            _commandList.Add(ModelMapper.GetCommand(rotationRobotModel));
        }

        #endregion

        #endregion
    }
}