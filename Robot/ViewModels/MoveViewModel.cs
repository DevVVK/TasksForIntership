using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Robot.ViewModels
{
    /// <summary>
    /// Класс представляющий модель-представления для окна команды движения
    /// </summary>
    public class MoveViewModel
    {
        #region Открытые свойства

        /// <summary>
        /// Количество клеток, на которое нужно переместить робота
        /// </summary>
        public int CellMoveCount { get; set; }

        /// <summary>
        /// Источник для выбора количества клеток, на которое может переместиться робот
        /// </summary>
        public ObservableCollection<int> CellMoveSource { get; set; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MoveViewModel()
        {
            
        }

        #endregion

        #region  Команды

        /// <summary>
        /// Команда перемещения робота
        /// </summary>
        public ICommand MoveRobotCommand { get; }

        #endregion
    }
}