using System;
using System.Collections.Generic;
using Emulator.LogicEmulator.Models;
using Emulator.ViewModels.Enumerables;
using RobotObjects.Commands;
using RobotObjects.Commands.Base;
using RobotObjects.Enumerables;
using RobotObjects.Objects;

namespace Emulator.LogicEmulator
{
    public class CommandInterpreter
    {
        private readonly Grid grid;
        private readonly Robot robot;

        public CommandInterpreter(Grid grid, Robot robot)
        {
            this.grid = grid;
            this.robot = robot;
        }

        /// <summary>
        /// Метод получающий команду
        /// </summary>
        /// <param name="source">источник команды <see cref="CommandModel"/></param>
        /// <returns></returns>
        private BaseRobotCommand GetCommand(CommandModel source)
        {
            switch ((CommandName)source.CurrentName)
            {
                case CommandName.Move: CreateMoveCommand(source); break;
                case CommandName.Rotation: CreateRotationCommand(source); break;
                case CommandName.Pouring: CreatePouringCommand(source); break;
                case CommandName.Learn: CreateLearnCellCommand(source); break;
            }
        }

        /// <summary>
        /// Метод возвращающий строку для исключения
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string GetMessage(string input) => $"Источник не является командой {input}";

        /// <summary>
        /// Метод 
        /// </summary>
        /// <param name="source"></param>
        private BaseRobotCommand CreateLearnCellCommand(CommandModel source)
        {
            if ((CommandName)source.CurrentName != CommandName.Move)
                throw new ArgumentException(GetMessage("изучения"));

            var learnCellCommand = new LearnCellCommand(_commands, grid, robot,
                source.CurrentOneParameter, source.CurrentTwoParameter)
            {
                Id = source.CommandId
            };

            return learnCellCommand;
        }

        private BaseRobotCommand CreatePouringCommand(CommandModel source)
        {
            if ((CommandName)source.CurrentName != CommandName.Pouring)
                throw new ArgumentException(GetMessage("заливки"));

            var pouringCommand = new PouringCellCommand(grid, robot, (ColorCell)source.CurrentOneParameter)
            {
                Id = source.CommandId,
                NextNumberCommand = source.CurrentTwoParameter
            };

            return pouringCommand;
        }

        private BaseRobotCommand CreateRotationCommand(CommandModel source)
        {
            if ((CommandName)source.CurrentName != CommandName.Rotation)
                throw new ArgumentException(GetMessage("поворота"));

            var rotationCommand = new RotationRobotCommand(robot, (RouteMove)source.CurrentOneParameter)
            {
                Id = source.CommandId,
                NextNumberCommand = source.CurrentTwoParameter
            };

            return rotationCommand;
        }

        private List<MoveRobotCommand> CreateMoveCommand(CommandModel source)
        {
            if ((CommandName)source.CurrentName != CommandName.Move)
                throw new ArgumentException(GetMessage("движения"));

            var moveCommandList = new List<MoveRobotCommand>();

            for (var i = 0; i < source.CurrentOneParameter; i++)
            {
                var moveCommand = new MoveRobotCommand(grid, robot)
                {
                    Id = source.CommandId,
                    NextNumberCommand = source.CurrentTwoParameter
                };

                moveCommandList.Add(moveCommand);
            }

            return moveCommandList;
        }

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
    }
}