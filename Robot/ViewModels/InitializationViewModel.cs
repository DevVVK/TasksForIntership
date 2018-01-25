using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Robot.ViewModels.Base;

namespace Robot.ViewModels
{
    public class InitializationViewModel : BaseViewModel
    {
        #region Закрытые поля

        /// <summary>
        /// Источник данных предоставляющий выбор количества строк в сетке
        /// </summary>
        private readonly List<int> _rowsSource;

        /// <summary>
        /// Источник данных предоставляющий выбор количества столбцов в сетке
        /// </summary>
        private readonly List<int> _columnsSource;

        #endregion

        #region Открытые свойства

        /// <summary>
        /// Количество строк в сетке 
        /// </summary>
        public int RowCount { get; set; }

        /// <summary>
        /// Количество столбцов в сетке
        /// </summary>
        public int ColumnCount { get; set; }

        /// <summary>
        /// Начальное положение робота (столбец)
        /// </summary>
        public int RowPoint { get; set; }

        /// <summary>
        /// Начальное положение робота (столбец)
        /// </summary>
        public int ColumnPoint { get; set; }

        /// <summary>
        /// Источник для выбора количества строк в сетке
        /// </summary>
        public List<int> RowsSource
        {
            get
            {
                InitializeSource(RowPointsSource, 0, RowCount);
                RowPoint = RowPointsSource.Count > 0 ? RowPointsSource[0] : 0;

                return _rowsSource;
            } 
        }

        /// <summary>
        /// Источник для выбора количества столбцов
        /// </summary>
        public List<int> ColumnsSource
        {
            get
            {
                InitializeSource(ColumnPointsSource, 0, ColumnCount);
                ColumnPoint = ColumnPointsSource.Count > 0 ? RowPointsSource[0] : 0;

                return _columnsSource;
            }
        }

        /// <summary>
        /// Источник для выбора строки начального положения робота
        /// </summary>
        public ObservableCollection<int> RowPointsSource { get; }

        /// <summary>
        /// Источник для выбора столбца начального положения робота
        /// </summary>
        public ObservableCollection<int> ColumnPointsSource { get; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчению
        /// </summary>
        public InitializationViewModel()
        {
            _rowsSource = new List<int>(); InitializeSource(_rowsSource, 5, 100);
            _columnsSource = new List<int>(); InitializeSource(_columnsSource, 5, 100);

            RowPointsSource = new ObservableCollection<int>();
            ColumnPointsSource = new ObservableCollection<int>();
        }

        #endregion

        #region Методы для инициализации источников данных

        /// <summary>
        /// Метод иницилизирующий источники данных
        /// </summary>
        /// <param name="recipient">приемник для записи значений</param>
        /// <param name="begin">начальное значение цикла</param>
        /// <param name="end">конечное значение цикла</param>
        private void InitializeSource(ICollection<int> recipient, int begin, int end)
        {
            recipient.Clear();

            for (var i = begin; i < end; i++) recipient.Add(i);
        }

        #endregion

        #region Команды 

        /// <summary>
        /// Команда инициализации сетки для робота
        /// </summary>
        public ICommand InitializeGrid { get; }

        #endregion 
    }
}