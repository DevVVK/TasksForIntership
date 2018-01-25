using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using RobotObjects.Objects.Enumerables;

namespace Robot.ViewModels
{
    /// <summary>
    /// Класс представляющий модель-представления для окна команды заливки ячейки
    /// </summary>
    public class PouringViewModel
    {
        #region Свойства для команды заливки ячейки, на которой находится робот

        /// <summary>
        /// Цвет заливки ячейки
        /// </summary>
        public ColorCell Color { get; set; }

        /// <summary>
        /// Источник для выбора цвета заливки ячейки
        /// </summary>
        public ObservableCollection<string> ColorVaiableSource { get; set; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public PouringViewModel()
        {
            
        }

        #endregion

        #region Команды 

        /// <summary>
        /// Команда заливки ячейки где находится робот
        /// </summary>
        public ICommand PouringCommand { get; }

        #endregion 
    }
}