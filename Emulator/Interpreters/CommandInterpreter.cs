using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows.Media;
using System.Windows.Shapes;
using Emulator.AttributeLogic;
using Emulator.Factories;
using Emulator.Mappers;
using Emulator.Models;
using RobotObjects.Commands;
using RobotObjects.Commands.Base;
using RobotObjects.EmulationEventArgs;
using RobotObjects.Objects;
using VisibleGrid = System.Windows.Controls.Grid;

namespace Emulator.Interpreters
{
    /// <summary>
    /// Класс представляющий интерпретатор команд
    /// </summary>
    public class CommandInterpreter
    {
        #region Закрытые поля 

        /// <summary>
        /// Список выполняемых команд
        /// </summary>
        private readonly ObservableCollection<CommandModel> _commandList;

        /// <summary>
        /// Робот-исполнитель
        /// </summary>
        private Robot _robot;
       
        /// <summary>
        /// Сетка в которой передвигается робот
        /// </summary>
        private Grid _grid;

        /// <summary>
        /// Отображаемая сетка
        /// </summary>
        private readonly VisibleGrid _visibleGrid;

        /// <summary>
        /// Отображаемый робот
        /// </summary>
        private Path _visibleRobot;

        /// <summary>
        /// Инициализвтор сетки
        /// </summary>
        private EmulatorManager _manager;

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="commandList">список команд для отображения в объеты команд</param>
        /// <param name="visibleGrid">отображаемая сетка</param>
        public CommandInterpreter(ObservableCollection<CommandModel> commandList, VisibleGrid visibleGrid)
        {
            _commandList = commandList;
            _visibleGrid = visibleGrid;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Метод получающий список команд
        /// </summary>
        /// <returns></returns>
        public List<BaseRobotCommand> GetCommandList()
        {
            return _commandList.Select(item => GetCommand(item)).ToList();
        }

        #endregion

        #region Закрытые методы

        /// <summary>
        /// Метод получающий команду
        /// </summary>
        /// <param name="source">источник команды <see cref="CommandModel"/></param>
        /// <returns></returns>
        private BaseRobotCommand GetCommand(CommandModel source)
        {
            BaseRobotCommand command = null;

            if (source.CommandName == AttributeManager.GetDescription(typeof(InitializeCommandModel)))
            {
                InitializeCommandModel model = CommandModelMapper.GetInitializeCommandModel(source);

                _grid = new Grid { RowCount = model.RowCount, ColumnCount = model.ColumnCount, Cells = new Cell[model.RowCount, model.ColumnCount]};
                _robot = new Robot { Row = model.RowPoint, Column = model.ColumnPoint };

                var initCommand = new InitializeEmulationCommand(_grid, _robot);
                initCommand.CreateEmulatorEvent += InitCommandOnExecuteEvent;

                command = initCommand;
            }

            if (source.CommandName == AttributeManager.GetDescription(typeof(MoveCommandModel)))
            {
                MoveCommandModel model = CommandModelMapper.GetMoveCommandModel(source);

                var moveCommand = new MoveRobotCommand(_grid, _robot, model.CellCount);
                moveCommand.MoveRobotEvent += MoveCommandOnExecuteEvent;
                
                command = moveCommand;
            }

            if (source.CommandName == AttributeManager.GetDescription(typeof(RotationCommandModel)))
            {
                RotationCommandModel model = CommandModelMapper.GetRotationCommandModel(source);

                var rotationCommand = new RotationRobotCommand(_robot, model.Route);
                rotationCommand.RotateRobotEvent += RotationCommandOnRotateRobot;

                command = rotationCommand;
            }

            if (source.CommandName == AttributeManager.GetDescription(typeof(PouringCellCommandModel)))
            {
                PouringCellCommandModel model = CommandModelMapper.GetPouringCommandModel(source);

                var pouringCommand = new PouringCellCommand(_grid, _robot, model.CellColor);
                pouringCommand.PouringCellEvent += PouringCommandOnPouringCellEvent;

                command = pouringCommand;
            }

            return command;
        }

        #endregion

        #region Обработчики событий выполнения команд

        /// <summary>
        /// Обработчик события инициализации эмулятора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void InitCommandOnExecuteEvent(object sender, InitializeEmulationEventArgs eventArgs)
        {
            _visibleGrid.Children.Clear();

            var robotInitializer = new RobotInitializer();
            _manager = new EmulatorManager(_visibleGrid, eventArgs.Cells, eventArgs.RowCount, eventArgs.ColumnCount);

            var sizeRobot = (int) _visibleGrid.Width / eventArgs.RowCount;

            _visibleRobot = robotInitializer.CreateRobot(sizeRobot, Colors.Coral);
            _manager.AddRobot(_visibleRobot, eventArgs.RowPoint, eventArgs.ColumnPoint);
        }

        /// <summary>
        /// Обработчик события движения робота
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void MoveCommandOnExecuteEvent(object sender, MoveRobotEventArgs eventArgs)
        {
            _manager.UpdatePointRobot(_visibleRobot, eventArgs.Row, eventArgs.Column);
        }

        /// <summary>
        /// Обработчик события поворота робота
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="rotationRobotEventArgs"></param>
        private void RotationCommandOnRotateRobot(object sender, RotationRobotEventArgs rotationRobotEventArgs)
        {

        }

        private void PouringCommandOnPouringCellEvent(object sender, PouringCellEventArgs pouringCellEventArgs)
        {
            _manager.UpdateColorCell(pouringCellEventArgs.Color, pouringCellEventArgs.Row, pouringCellEventArgs.Column);
        }

        #endregion
    }
}