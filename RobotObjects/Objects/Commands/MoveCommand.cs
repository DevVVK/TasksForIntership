using RobotObjects.Objects.Base;
using RobotObjects.Objects.Enumerables;
using RobotObjects.Objects.Grid;

namespace RobotObjects.Objects.Commands
{
    /// <summary>
    /// Класс представляющий  движения робота на выбранное количество клеток
    /// </summary>
    public class MoveCommand : BaseRobotCommand
    {
        #region Открытые свойства



        #endregion

        #region Закрытые поля

        /// <summary>
        /// Поле для хранения количества клеток, на которое нужно переместить робота
        /// </summary>
        private readonly int _cellCount;

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="gridRobot">сетка, по которой перемещается робот</param>
        /// <param name="robot">робот, которого нужно переместить</param>
        /// <param name="cellCount">количество клеток, на которое нужно переместить робота</param>
        public MoveCommand(GridRobot gridRobot, Robot robot, int cellCount)
        {
            //поля
            GridRobot = gridRobot;
            Robot = robot;
            _cellCount = cellCount;

            //методы
            ExecuteMethod = Move;
            CanExecuteMethod = CheckMove;

            //добавить данную команду в список команд
            CommandList.Add(this);
        }

        #endregion

        #region Методы

        /// <summary>
        /// Метод проверяющий возможность движения робота
        /// </summary>
        /// <returns>true - пусть свободен, иначе false</returns>
        private bool CheckMove()
        {
            switch (Robot.RouteMove)
            {
                case RouteMove.Left:
                    return Robot.Column - _cellCount < 0 || GridRobot.Cells[Robot.Row][Robot.Column - _cellCount].IsMove;

                case RouteMove.Right:
                    return Robot.Column + _cellCount > GridRobot.ColumnCount || GridRobot.Cells[Robot.Row][Robot.Column + _cellCount].IsMove;
               
                case RouteMove.Top:
                    return Robot.Row - _cellCount < 0 || GridRobot.Cells[Robot.Row - _cellCount][Robot.Column].IsMove;

                case RouteMove.Bottom:
                    return Robot.Row + _cellCount > GridRobot.RowCount || GridRobot.Cells[Robot.Row + _cellCount][Robot.Column].IsMove;
            }

            return false;
        }

        /// <summary>
        /// Команда движения на указанное количество клеток
        /// </summary>
        private void Move()
        {
            switch (Robot.RouteMove)
            {
                case RouteMove.Left:
                    Robot.Column = Robot.Column - _cellCount;

                    break;

                case RouteMove.Right:
                    Robot.Column = Robot.Column + _cellCount;

                    break;

                case RouteMove.Top:
                    Robot.Row = Robot.Row - _cellCount;

                    break;

                case RouteMove.Bottom:
                    Robot.Row = Robot.Row + _cellCount;

                    break;
            }
        }

        #endregion
    }
}