using System;
using RobotObjects.Commands.Base;
using RobotObjects.EmulationEventArgs;
using RobotObjects.Enumerables;
using RobotObjects.Exceptions;
using RobotObjects.Objects;

namespace RobotObjects.Commands
{
    /// <summary>
    /// Класс представляющий  движения робота на выбранное количество клеток
    /// </summary>
    public class MoveRobotCommand : BaseRobotCommand
    {
        /// <summary>
        /// Событие для обновления объектов эмулятора
        /// </summary>
        private EventHandler<MoveRobotEventArgs> _executeEvent;

        /// <summary>
        /// Событие для обновления объектов эмулятора
        /// </summary>
        public event EventHandler<MoveRobotEventArgs> MoveRobotEvent
        {
            add => _executeEvent += value;
            remove
            {
                if (value == null) return;
                if (_executeEvent != null)
                {
                    // ReSharper disable once DelegateSubtraction
                    _executeEvent -= value;
                }
            }
        }

        /// <summary>
        ///  Метод вызывающий обработчик события
        /// </summary>
        private void OnExecuteEvent(object sender, MoveRobotEventArgs e) => _executeEvent?.Invoke(sender, e);

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
        /// <param name="grid">сетка, по которой перемещается робот</param>
        /// <param name="robot">робот, которого нужно переместить</param>
        /// <param name="cellCount">количество клеток, на которое нужно переместить робота</param>
        public MoveRobotCommand(Grid grid, Robot robot, int cellCount)
        {
            Grid = grid;
            Robot = robot;
            _cellCount = cellCount;

            Execute = Move;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Метод для перемещения робота по указанному направлению
        /// </summary>
        private void Move()
        {
            switch (Robot.RouteMove)
            {
                case RouteMove.Right: UpdateMove(Grid.Cells, Robot, _cellCount, () => Robot.Column++); break;
                case RouteMove.Top: UpdateMove(Grid.Cells, Robot, _cellCount, () => Robot.Row--); break;
                case RouteMove.Left: UpdateMove(Grid.Cells, Robot, _cellCount, () => Robot.Column--); break;
                case RouteMove.Bottom: UpdateMove(Grid.Cells, Robot, _cellCount, () => Robot.Row++); break;
            }
        }

        /// <summary>
        /// Метод для передвижения робота
        /// </summary>
        /// <param name="cells">сетка</param>
        /// <param name="robot">робот</param>
        /// <param name="cellCount">количество ячеек, на которое нужно переместить робота</param>
        /// <param name="iteration">метод изменения индекса строки или столбца</param>
        private void UpdateMove(Cell[,] cells, Robot robot, int cellCount, Action iteration)
        {
            for (var index = 0; index < cellCount; index++)
            {
                CheckCellOnMove(cells, robot);
                iteration?.Invoke();
                OnExecuteEvent(this, new MoveRobotEventArgs(Robot.Row, Robot.Column));
            }
        }

        /// <summary>
        /// Метод для проверки проходимости ячейки по указанному напрпавлению 
        /// </summary>
        /// <param name="cells">сетка</param>
        /// <param name="robot">робот</param>
        private void CheckCellOnMove(Cell[,] cells, Robot robot)
        {
            switch (robot.RouteMove)
            {
                case RouteMove.Right: CheckInException(cells, robot.Row, robot.Column + 1); break;
                case RouteMove.Left: CheckInException(cells, robot.Row, robot.Column - 1); break;
                case RouteMove.Top: CheckInException(cells, robot.Row - 1, robot.Column); break;
                case RouteMove.Bottom: CheckInException(cells, robot.Row + 1, robot.Column); break;
            }
        }

        /// <summary>
        /// Метод для проверки проходимости ячейки, если ячейка на проходимя, 
        /// то выбрасывается искючение см. <see cref="NotIsMoveInCellException"/> 
        /// </summary>
        /// <param name="cells">сетка</param>
        /// <param name="row">индекс строки ячейкистрока</param>
        /// <param name="column">индекс столбца ячейки</param>
        private void CheckInException(Cell[,] cells, int row, int column)
        {
            if (!cells[row, column].IsMove) throw new NotIsMoveInCellException();
        }

        #endregion
    }
}