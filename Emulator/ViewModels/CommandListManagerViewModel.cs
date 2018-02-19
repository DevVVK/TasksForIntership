using System.Collections.ObjectModel;
using System.Linq;
using Emulator.Commands.Base;
using Emulator.Interpreters;
using Emulator.Models;
using Emulator.ViewModels.Base;

namespace Emulator.ViewModels
{
    /// <summary>
    /// Класс представляющий модель-представления части отвечающей за выполнение списка команд
    /// </summary>
    public class CommandListManagerViewModel : BaseViewModel
    {
        #region Открытые свойства

        /// <summary>
        /// Список команд выполняемых роботом
        /// </summary>
        private readonly CommandInterpreter _interpreter;

        /// <summary>
        /// Спиосок команд
        /// </summary>
        public ObservableCollection<CommandModel> CommandListInterface { get; }

        #endregion

        #region Конструкторы 

        /// <summary>
        /// Конструктор по умолчению
        /// </summary>
        /// <param name="interpreter">интерпретатор команд</param>
        public CommandListManagerViewModel(CommandInterpreter interpreter)
        {
            CommandListInterface = new ObservableCollection<CommandModel>();
            _interpreter = interpreter;
            _interpreter.CommandList = CommandListInterface;
            AddCommand = new BaseCommandRelay(AddCommandInList);
            StartEmulationCommand = new BaseCommandRelay(StartEmulation);
            StartStepEmulationCommand = new BaseCommandRelay(StartStepEmulation);
            ClearListCommand = new BaseCommandRelay(ClearList);
            RemoveCommand = new BaseCommandRelay(RemoveCommandFromList);
        }

        #endregion

        #region Команды

        /// <summary>
        /// Команда для добавления команды в список команд
        /// </summary>
        public BaseCommandRelay AddCommand { get; }

        /// <summary>
        /// Команда запускающая исполнение список команд
        /// </summary>
        public BaseCommandRelay StartEmulationCommand { get; }

        /// <summary>
        /// Команда запускающая пошаговое выполнение списка команд
        /// </summary>
        public BaseCommandRelay StartStepEmulationCommand { get; }

        /// <summary>
        /// Команда очищающая список команд
        /// </summary>
        public BaseCommandRelay ClearListCommand { get; }

        /// <summary>
        /// Команда удаления команды из списка
        /// </summary>
        public BaseCommandRelay RemoveCommand { get; }

        #endregion

        #region Методы 

        /// <summary>
        /// Метод для удаления команды из списка
        /// </summary>
        /// <param name="parameter"></param>
        private void RemoveCommandFromList(object parameter)
        {
            if (!(parameter is int id)) return;
            var removeModel = CommandListInterface.First(item => item.CommandId == id);

            CommandListInterface.Remove(removeModel);
        }

        /// <summary>
        /// Метод для добавления команды в список команд
        /// </summary>
        private void AddCommandInList(object parameter)
        {
            var model = new CommandModel();
            CommandListInterface.Add(model);

            var index = CommandListInterface.Max(item => item.CommandId);
            model.CommandId = ++index;
        }

        /// <summary>
        /// Метод запускающий выполнение команд с шагом в 1 секунду
        /// </summary>
        private void StartEmulation(object parameter)
        {
            _interpreter.StartInvoked();
        }

        /// <summary>
        /// Метод запускающий пошаговое выполнение команд
        /// </summary>
        private void StartStepEmulation(object parameter)
        {

        }

        /// <summary>
        /// Метод очищающий список команд
        /// </summary>
        private void ClearList(object parameter)
        {

        }

        #endregion
    }
}