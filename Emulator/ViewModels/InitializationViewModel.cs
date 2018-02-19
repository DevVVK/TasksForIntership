using System.Collections.Generic;
using System.Linq;
using Emulator.Commands.Base;
using Emulator.Interpreters;
using Emulator.ViewModels.Base;
using Emulator.ViewModels.ModelsForView;

namespace Emulator.ViewModels
{
    /// <summary>
    /// Класс представляющей модель-представления управления командой инициализации сетки 
    /// и установки робота указанное положение
    /// </summary>
    public class InitializationViewModel : BaseViewModel
    {
        #region Закрытые поля

        /// <summary>
        /// Количество строк в сетке
        /// </summary>
        private int _rowCount;

        /// <summary>
        /// Количество столбцов в сетке
        /// </summary>
        private int _columnCount;

        /// <summary>
        /// Интерпретатор команд
        /// </summary>
        private readonly CommandInterpreter _interpreter;

        #endregion

        #region Открытые свойства

        /// <summary>
        /// Количество строк в сетке 
        /// </summary>
        public int RowCount
        {
            get => _rowCount;
            set
            {
                if (_rowCount != value)
                {
                    _rowCount = value;
                    RowPointsSource = GetSource(1, value-1);
                    RowPoint = RowPointsSource[0].Value;
                    OnPropertyChanged(nameof(RowPoint));
                }
            }
        }
        /// <summary>
        /// Источник данных для выбора количества строк
        /// </summary>
        public List<BaseCombo> RowsSource { get; }

        /// <summary>
        /// Количество столбцов в сетке
        /// </summary>
        public int ColumnCount
        {
            get => _columnCount;
            set
            {
                if (_columnCount != value)
                {
                    _columnCount = value;
                    ColumnPointsSource = GetSource(1, value - 1);
                    ColumnPoint = ColumnPointsSource[0].Value;
                    OnPropertyChanged(nameof(ColumnPoint));
                }
            }
        }
        /// <summary>
        /// Источник для выбора количества столбцов
        /// </summary>
        public List<BaseCombo> ColumnsSource { get; }

        /// <summary>
        /// Начальное положение робота (столбец)
        /// </summary>
        public int RowPoint { get; set; }
        /// <summary>
        /// Источник для выбора строки начального положения робота
        /// </summary>
        public List<BaseCombo> RowPointsSource { get; set; }

        /// <summary>
        /// Начальное положение робота (столбец)
        /// </summary>
        public int ColumnPoint { get; set; }
        /// <summary>
        /// Источник для выбора столбца начального положения робота
        /// </summary>
        public List<BaseCombo> ColumnPointsSource { get; set; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчению
        /// <param name="commandList">список команд выполняемых роботом</param>
        /// </summary>
        public InitializationViewModel(CommandInterpreter interpreter)
        {
            _interpreter = interpreter;

            RowsSource = GetSource(10, 100);
            ColumnsSource = RowsSource;

            CreateGridCommand = new BaseCommandRelay(CreateGrid);
        }

        #endregion

        /// <summary>
        /// Метод генерации чисел для источников
        /// </summary>
        /// <param name="begin">начало интервала</param>
        /// <param name="end">коней интервала</param>
        /// <returns></returns>
        private List<BaseCombo> GetSource(int begin, int end)
        {
            return Enumerable.Range(begin, end - begin).Select(item => new BaseCombo{Name = item.ToString(), Value = item}).ToList();
        }

        #region Команды 

        /// <summary>
        /// Команда создания сетки
        /// </summary>
        public BaseCommandRelay CreateGridCommand { get; }

        #endregion

        #region Методы

        /// <summary>
        /// Метод создания сетки
        /// </summary>
        private void CreateGrid(object parameter)
        {
            _interpreter.CreateGrid(RowCount, ColumnCount, RowPoint, ColumnPoint);
        }

        #endregion

    }
}