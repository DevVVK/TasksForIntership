using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using Emulator.Factories;
using Emulator.Mappers;
using Emulator.Models;
using Emulator.ViewModels.Enumerables;
using RobotObjects.Commands;
using RobotObjects.Commands.Base;
using RobotObjects.EmulationEventArgs;
using RobotObjects.Exceptions;
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
        /// Ссылка на объект класса создания робота
        /// </summary>
        private readonly RobotInitializer _robotInitializer;

        /// <summary>
        /// Отображаемая сетка
        /// </summary>
        private readonly VisibleGrid _visibleGrid;
        
        /// <summary>
        /// Отображаемый робот
        /// </summary>
        private Path _visibleRobot;

        /// <summary>
        /// Робот-исполнитель
        /// </summary>
        private Robot _robot;
       
        /// <summary>
        /// Сетка в которой передвигается робот
        /// </summary>
        private Grid _grid;

        /// <summary>
        /// Инициализвтор сетки
        /// </summary>
        private EmulatorManager _manager;

        /// <summary>
        /// Таймер для посекундного выполнения команд
        /// </summary>
        private readonly DispatcherTimer _invokator;

        /// <summary>
        /// Ссылка на вызывающий метод
        /// </summary>
        private Action _invokeMethod;

        /// <summary>
        /// Очередь для хранения списка команд
        /// </summary>
        private readonly Queue<Action> _invokedMethods;

        /// <summary>
        /// Список команд для команды изучения ячейки
        /// </summary>
        private readonly List<BaseRobotCommand> _commands;

        #endregion

        /// <summary>
        /// Список команд
        /// </summary>
        public ObservableCollection<CommandModel> CommandList { get; set; }

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="commandList">список команд для отображения в объеты команд</param>
        /// <param name="visibleGrid">отображаемая сетка</param>
        public CommandInterpreter(VisibleGrid visibleGrid)
        {
            _visibleGrid = visibleGrid;
            _commands = new List<BaseRobotCommand>();
            _robotInitializer = new RobotInitializer();
            _invokedMethods = new Queue<Action>();
            _invokator = new DispatcherTimer(new TimeSpan(0,0,1), DispatcherPriority.Normal, CreateQueueCommands, Dispatcher.CurrentDispatcher);
            _invokator.Tick += timer_tick;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Метод для запуска выполнения команд
        /// </summary>
        /// <param name="commandList">список выполняемых команд</param>
        public void StartInvoked()
        {
            _invokator.Start();
        }

        /// <summary>
        /// Метод для остановки выполнения команд
        /// </summary>
        public void StopInvoked()
        {
            _invokator.Stop();
        }

        /// <summary>
        /// Метод для очистки списка команд
        /// </summary>
        /// <param name="commandList">список выполняемых команд</param>
        public void ClearCommandList(ObservableCollection<CommandModel> commandList)
        {
            commandList.Clear();

            _invokator.Stop();
            _invokedMethods.Clear();
        }

        /// <summary>
        /// Метод для создания сетки и робота 
        /// </summary>
        /// <param name="rowCount">количество строк</param>
        /// <param name="columnCount">количество столбцов</param>
        /// <param name="rowPoint">местоположение робота в строке</param>
        /// <param name="columnPoint">местоположение робота в столбце</param>
        public void CreateGrid(int rowCount, int columnCount, int rowPoint, int columnPoint)
        {
            _robot = new Robot { Row = rowPoint, Column = columnPoint };
            _grid = new Grid { RowCount = rowCount, ColumnCount = columnCount, Cells = new Cell[rowCount, columnCount] };
            var initCommand = new InitializeEmulationCommand(_grid, _robot);
            _visibleGrid.Children.Clear();
            _manager = new EmulatorManager(_visibleGrid, _grid.Cells, rowCount, columnCount);
            _visibleRobot = _robotInitializer.CreateRobot(Colors.Coral);
            _manager.AddRobot(_visibleRobot, rowPoint, columnPoint);
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

            switch ((CommandName)source.CurrentName)
            {
                case CommandName.Move:
                    MoveCommandModel moveModel = CommandModelMapper.GetMoveCommandModel(source);
                    var moveCommand = new MoveRobotCommand(_grid, _robot, moveModel.CellCount);
                    moveCommand.MoveRobotEvent += MoveCommandOnExecuteEvent;
                    command = moveCommand;
                    _commands.Add(command);

                    break;

                case CommandName.Rotation:
                    RotationCommandModel rotationModel = CommandModelMapper.GetRotationCommandModel(source);
                    var rotationCommand = new RotationRobotCommand(_robot, rotationModel.Route);
                    rotationCommand.RotateRobotEvent += RotationCommandOnRotateRobot;
                    command = rotationCommand;
                    _commands.Add(command);

                    break;

                case CommandName.Pouring:
                    PouringCellCommandModel pouringModel = CommandModelMapper.GetPouringCommandModel(source);
                    var pouringCommand = new PouringCellCommand(_grid, _robot, pouringModel.CellColor);
                    pouringCommand.PouringCellEvent += PouringCommandOnPouringCellEvent;
                    command = pouringCommand;
                    _commands.Add(command);

                    break;

                case CommandName.Learn:
                    LearnCellCommandModel learnCellModel = CommandModelMapper.GetLearnCellCommandModel(source);
                    var learnCellCommand = new LearnCellCommand(_commands, _grid, _robot, 
                        learnCellModel.CommandIdIfCellColorBlack, learnCellModel.CommandIdIfCellColorWhite);
                    command = learnCellCommand;
                    _commands.Add(command);

                    break;
            }

            return command;
        }
       
        #endregion

        #region Обработчики событий выполнения команд

        /// <summary>
        /// Обработчик события движения робота
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="moveRobotEventArgs"></param>
        private void MoveCommandOnExecuteEvent(object sender, MoveRobotEventArgs moveRobotEventArgs)
        {
            _invokeMethod = () => _manager.UpdatePointRobot(_visibleRobot, moveRobotEventArgs.Row, moveRobotEventArgs.Column);
            _invokedMethods.Enqueue(_invokeMethod);
        }

        /// <summary>
        /// Обработчик события поворота робота
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="rotationRobotEventArgs"></param>
        private void RotationCommandOnRotateRobot(object sender, RotationRobotEventArgs rotationRobotEventArgs)
        {
            _invokeMethod = () => _manager.RotationRobot(_visibleRobot, rotationRobotEventArgs.RouteMove);
            _invokedMethods.Enqueue(_invokeMethod);
        }

        /// <summary>
        /// Обработчик события заливки ячейки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="pouringCellEventArgs"></param>
        private void PouringCommandOnPouringCellEvent(object sender, PouringCellEventArgs pouringCellEventArgs)
        {
            _invokeMethod = () => _manager.UpdateColorCell(pouringCellEventArgs.Color, pouringCellEventArgs.Row, pouringCellEventArgs.Column);
            _invokedMethods.Enqueue(_invokeMethod);
        }

        private int _commandIndex;

        /// <summary>
        /// Обработчик события для вызова команд из очереди
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void timer_tick(object sender, EventArgs args)
        {
            if (_invokedMethods?.Count == 0)
            {
                return;
            }

            _invokedMethods?.Dequeue().Invoke();
        }

        /// <summary>
        /// Метод для формирования очереди команд
        /// </summary>
        private void CreateQueueCommands(object sender, EventArgs args)
        {
            if (CommandList.Count == _commandIndex)
            {
                _invokator.Stop();
                _commandIndex = 0;
                return;
            }

            try
            {
                GetCommand(CommandList[_commandIndex]).ExecuteMethod();
            }
            catch (NotIsMoveInCellException exception)
            {
                return;   
            }

            _commandIndex++;
        }

        #endregion
    }
}