using System;
using RobotObjects.Commands.Base;
using RobotObjects.EmulationEventArgs;
using RobotObjects.Enumerables;
using RobotObjects.Objects;

namespace RobotObjects.Commands
{
    /// <summary>
    /// Класс представляющий команду заливки ячейки выбранным цветом
    /// </summary>
    public class PouringCellCommand : BaseRobotCommand
    {
        /// <summary>
        /// Событие для обновления объектов эмулятора
        /// </summary>
        private EventHandler<PouringCellEventArgs> _executeEvent;

        /// <summary>
        /// Объект заглушка для взаимной блокировки потоков
        /// </summary>
        private readonly object _locker = new object();

        /// <summary>
        /// Событие для обновления объектов эмулятора
        /// </summary>
        public event EventHandler<PouringCellEventArgs> PouringCellEvent
        {
            add
            {
                lock (_locker)
                {
                    _executeEvent += value;
                }
            }
            remove
            {
                lock (_locker)
                {
                    if (value != null)
                        _executeEvent -= value;

                }
            }
        }

        /// <summary>
        ///  Метод вызывающий обработчик события
        /// </summary>
        private void OnExecuteEvent(object sender, PouringCellEventArgs e) => _executeEvent?.Invoke(sender, e);

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
        /// <param name="grid">сетка, по которой передвигается робот</param>
        /// <param name="robot">робот</param>
        /// <param name="pouringColor">цвет заливки ячейки, в которой находится робот</param>
        public PouringCellCommand(Grid grid, Robot robot, ColorCell pouringColor)
        {
            Grid = grid;
            Robot = robot;
            _pouringColor = pouringColor;
            Execute = PouringCell;
        }

        #endregion

        #region Методы 

        /// <summary>
        /// Метод изменяющий цвет ячейки, на которой находится робот
        /// </summary>
        private void PouringCell()
        {
            //извлечение ячейки на которой стоит робот
            var cell = Grid.Cells[Robot.Row, Robot.Column];

            if (cell == null) return;
            
            //изменение цвета
            cell.Color = _pouringColor;
            OnExecuteEvent(this, new PouringCellEventArgs(Robot.Row, Robot.Column, cell.Color));
        }

        #endregion
    }
}