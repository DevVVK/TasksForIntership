using System.Collections.Generic;
using RobotObjects.Commands.Base;
using RobotObjects.Enumerables;
using RobotObjects.Objects;

namespace RobotObjects.Commands
{
    /// <summary>
    /// Класс представляющий команду изучения ячейки
    /// </summary>
    public class LearnCellCommand : BaseRobotCommand
    {
        #region Закрытые поля

        /// <summary>
        /// Номер команды если цвет ячейки черный
        /// </summary>
        private readonly int _numberCommandIfBlackColor;

        /// <summary>
        /// Номер команды если цвет ячейки белый
        /// </summary>
        private readonly int _numberCommandIfWhiteColor;

        /// <summary>
        /// Список выполняемых команд
        /// </summary>
        private readonly List<BaseRobotCommand> _commandList;

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="commandList">список выполняемых команд</param>
        /// <param name="grid">сетка, в которой передвигается робот</param>
        /// <param name="robot">робот находящийся в определенной ячейке</param>
        /// <param name="numberCommandIfBlackColor">номер команды, к которой нужно перейти если цвет ячейки черный</param>
        /// <param name="numberCommandIfWhiteColor">номер команды, к которой нужно перейти если цвет ячейки белый</param>
        public LearnCellCommand(List<BaseRobotCommand> commandList, Grid grid, Robot robot, 
                                int numberCommandIfBlackColor, int numberCommandIfWhiteColor)
        {
            Grid = grid;
            Robot = robot;

            _commandList = commandList;
            _numberCommandIfBlackColor = numberCommandIfBlackColor;
            _numberCommandIfWhiteColor = numberCommandIfWhiteColor;

            Execute = LearnCell;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Изучает ячейку на предмет цвета и выполняет список команд с заданного индекса
        /// </summary>
        public void LearnCell()
        {
            var color = GetColorCell(Robot.Row, Robot.Column);

            switch (color)
            {
                case ColorCell.Black:
                    for (var commandIndex = _numberCommandIfBlackColor; commandIndex < _commandList.Count; commandIndex++)
                    {
                        _commandList[commandIndex].ExecuteMethod();
                    }
                    break;

                case ColorCell.White:
                    for (var commandIndex = _numberCommandIfWhiteColor; commandIndex < _commandList.Count; commandIndex++)
                    {
                        _commandList[commandIndex].ExecuteMethod();
                    }
                    break;
            }
        }

        /// <summary>
        /// Получает цвет ячейки, в которой находится робот
        /// </summary>
        /// <returns></returns>
        private ColorCell GetColorCell(int row, int column) => Grid.Cells[row, column].Color;

        #endregion
    }
}