using RobotObjects.Objects.Base;
using RobotObjects.Objects.Enumerables;

namespace RobotObjects.Objects.Commands
{
    /// <summary>
    /// Класс представляющий команду заливки ячейки выбранным цветом
    /// </summary>
    public class PouringCommand : BaseRobotCommand
    {
        #region Закрытые поля

        /// <summary>
        /// Цвет заливки ячейки, в которой находится робот
        /// </summary>
        private readonly ColorCell _pouringColor;

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="gridRobot">сетка, по которой передвигается робот</param>
        /// <param name="robot">робот</param>
        /// <param name="pouringColor">цвет заливки ячейки, в которой находится робот</param>
        public PouringCommand(GridRobot gridRobot, Robot robot, ColorCell pouringColor)
        {
            // поля
            Robot = robot;
            GridRobot = gridRobot;
            _pouringColor = pouringColor;

            //методы
            ExecuteMethod = PouringCell;

            //добавить данную команду в список команд
            CommandList.Add(this);
        }

        #endregion

        #region Методы 

        /// <summary>
        /// Метод изменяющий цвет ячейки, на которой находится робот
        /// </summary>
        private void PouringCell()
        {
            //извлечение ячейки на которой стоит робот
            var cell = GridRobot.Cells[Robot.Row][Robot.Column];

            //изменение цвета
            if (cell != null) cell.Color = _pouringColor;
        }

        #endregion
    }
}