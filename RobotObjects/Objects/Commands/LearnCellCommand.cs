using System;
using RobotObjects.Objects.Base;
using RobotObjects.Objects.Enumerables;
using RobotObjects.Objects.Grid;

namespace RobotObjects.Objects.Commands
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

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="gridRobot">сетка, по которой передвигается робот</param>
        /// <param name="robot">робот находящийся в определенной ячейке</param>
        /// <param name="numberCommandIfBlackColor">номер команды, к которой нужно перейти если цвет ячейки черный</param>
        /// <param name="numberCommandIfWhiteColor">номер команды, к которой нужно перейти если цвет ячейки белый</param>
        public LearnCellCommand(GridRobot gridRobot, Robot robot, int numberCommandIfBlackColor, int numberCommandIfWhiteColor)
        {
            //поля
            GridRobot = gridRobot;
            Robot = robot;

            _numberCommandIfBlackColor = numberCommandIfBlackColor;
            _numberCommandIfWhiteColor = numberCommandIfWhiteColor;

            //методы
            ExecuteMethod = LearnCell;

            //добавить данную команду в список команд
            CommandList.Add(this);
        }

        #endregion

        #region Методы

        /// <summary>
        /// Изучает ячейку на предмет цвета и выполняет список команд с заданного индекса
        /// </summary>
        public void LearnCell()
        {
            var color = GetColorCell();

            switch (color)
            {
                case ColorCell.Black:
                    for (var commandIndex = _numberCommandIfBlackColor; commandIndex < CommandList.Count; commandIndex++)
                    {
                        CommandList[commandIndex].Execute();
                    }
                    break;

                case ColorCell.White:
                    for (var commandIndex = _numberCommandIfWhiteColor; commandIndex < CommandList.Count; commandIndex++)
                    {
                        CommandList[commandIndex].Execute();
                    }
                    break;
            }
        }

        /// <summary>
        /// Получает цвет ячейки, в которой находится робот
        /// </summary>
        /// <returns></returns>
        private ColorCell GetColorCell()
        {
            return GridRobot.Cells[Robot.Row][Robot.Column].Color;
        }

        #endregion
    }
}