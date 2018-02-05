using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Controls;
using Emulator.Commands.Base;
using Emulator.Interpreters;
using Emulator.Models;
using Emulator.ViewModels.Base;
using RobotObjects.Commands.Base;

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

        /// <summary>
        /// Ссылка на визуальную сетку
        /// </summary>
        private Grid _visualGrid;

        /// <summary>
        /// Интерпретатор команд
        /// </summary>
        private CommandInterpreter _manager;

        /// <summary>
        /// Список объектов команды
        /// </summary>
        private List<BaseRobotCommand> _readyCommandList;

        /// <summary>
        /// Поле для команды запуска робота-исполнителя
        /// </summary>
        private BaseCommandRelay _startEmulationCommand;

        /// <summary>
        /// Поле для команды пошагового выполнения списка команд
        /// </summary>
        private BaseCommandRelay _startStepEmulationCommand;

        /// <summary>
        /// Поле для команды очистки списка команд
        /// </summary>
        private BaseCommandRelay _clearListCommand;

        #endregion

        #region Конструкторы 

        /// <summary>
        /// Конструктор по умолчению
        /// </summary>
        /// <param name="commandList">спико комманд вы полняемых роботом</param>
        /// <param name="grid">визуальная сетка</param>
        public CommandListManagerViewModel(ObservableCollection<CommandModel> commandList, Grid grid)
        {
            _visualGrid = grid;
            _commandList = commandList;
            _readyCommandList = new List<BaseRobotCommand>();
        }

        #endregion

        #region Команды

        /// <summary>
        /// Команда запускающая исполнение список команд
        /// </summary>
        public BaseCommandRelay StartEmulationCommand =>
            _startEmulationCommand ?? (_startEmulationCommand = new BaseCommandRelay(StartEmulation));

        /// <summary>
        /// Команда запускающая пошаговое выполнение списка команд
        /// </summary>
        public BaseCommandRelay StartStepEmulationCommand => 
            _startStepEmulationCommand ?? (_startStepEmulationCommand = new BaseCommandRelay(StartStepEmulation));

        /// <summary>
        /// Команда очищающая список команд
        /// </summary>
        public BaseCommandRelay ClearListCommand =>
            _clearListCommand ?? (_clearListCommand = new BaseCommandRelay(ClearList));

        #endregion

        #region Методы 

        /// <summary>
        /// Метод запускающий выполнение команд с шагом в 1 секунду
        /// </summary>
        private void StartEmulation()
        {
            _manager = new CommandInterpreter(_commandList, _visualGrid);

            foreach (var command in _manager.GetCommandList())
            {
                command.ExecuteMethod();
            }
        }

        /// <summary>
        /// Метод запускающий пошаговое выполнение команд
        /// </summary>
        private void StartStepEmulation()
        {

        }

        /// <summary>
        /// Метод очищающий список команд
        /// </summary>
        private void ClearList()
        {

        }

        #endregion
    }
}