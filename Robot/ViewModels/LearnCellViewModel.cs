using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Robot.ViewModels
{
    /// <summary>
    /// Класс представляющий модель-представления окна команды изучения ячейки на предмет цвета
    /// </summary>
    public class LearnCellViewModel
    {
        #region Открытые свойства

        /// <summary>
        /// Номер команды если цвет ячейки черный
        /// </summary>
        public int NumberCommandIfCellBlack { get; set; }

        /// <summary>
        /// Номер команды если цвет ячейки белый
        /// </summary>
        public int NumberCommandIfCellWhite { get; set; }

        /// <summary>
        /// Источник для выбора номера команды если цвет ячейки черный
        /// </summary>
        public ObservableCollection<int> NumbersCommandIfCellBlackSource { get; set; }

        /// <summary>
        /// Источник для выбора номера команды если цвет ячейки белый
        /// </summary>
        public ObservableCollection<int> NumberCommandIfCellWhiteSource { get; set; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public LearnCellViewModel()
        {
            
        }

        #endregion

        #region Команды

        /// <summary>
        /// Команда изучения цвета заливки ячейки, на которой находится робот
        /// </summary>
        public ICommand LearnCellCommand { get; }

        #endregion
    }
}