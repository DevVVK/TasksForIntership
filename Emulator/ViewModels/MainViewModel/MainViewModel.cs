using System.Collections.ObjectModel;
using System.Windows.Controls;
using Emulator.Models;
using Emulator.ViewModels.Base;
using RobotObjects.Commands.Base;

namespace Emulator.ViewModels.MainViewModel
{
    /// <summary>
    /// Класс представляющий модель-представления эмулятора среды разработки и выполнения алгоритма для робота
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        #region Открытые свойства

        /// <summary>
        /// Список выполняемых команд для отображения
        /// </summary>
        public ObservableCollection<CommandModel> CommandList { get; }

        /// <summary>
        /// Список выполненяемых команд
        /// </summary>
        public ObservableCollection<BaseRobotCommand> CommandObjectList;  

        /// <summary>
        /// Свойство представляющее объект управления командой инициализации сетки
        /// </summary>
        public InitializationViewModel InitializationGridFields { get; }

        /// <summary>
        /// Свойство представляющее объект управления командой изучения ячейки, на которой находится робот
        /// </summary>
        public LearnCellViewModel LearnerCellWhereLocationRobot { get; }

        /// <summary>
        /// Свойство представляющее объект управления командой перемещения робота на определенное количество ячеек
        /// </summary>
        public MoveViewModel MoveRobotInCell { get; }

        /// <summary>
        /// Свойство представляющее объект управления командой заливки ячейки, на которой находится робот
        /// </summary>
        public PouringViewModel PouringCellWhereLocationRobot { get; }

        /// <summary>
        /// Свойство представляющее объект управления командой поворота робота в указанную сторону
        /// </summary>
        public RotationViewModel RotationInSelectCell { get; }

        /// <summary>
        /// Свойство представляющее объект команды запуска выполнения списка команд
        /// </summary>
        public CommandListManagerViewModel CommandListManager { get; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MainViewModel(Grid visualGrid)
        {
            CommandObjectList = new ObservableCollection<BaseRobotCommand>();
            CommandList = new ObservableCollection<CommandModel>();

            MoveRobotInCell = new MoveViewModel(CommandList);
            RotationInSelectCell = new RotationViewModel(CommandList);
            InitializationGridFields = new InitializationViewModel(CommandList);
            LearnerCellWhereLocationRobot = new LearnCellViewModel(CommandList);
            PouringCellWhereLocationRobot = new PouringViewModel(CommandList);
            CommandListManager = new CommandListManagerViewModel(CommandList, visualGrid);
        }

        #endregion
    }
}