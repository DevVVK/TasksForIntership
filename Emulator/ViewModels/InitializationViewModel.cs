using System.Collections.Generic;
using System.Collections.ObjectModel;
using Emulator.Commands.Base;
using Emulator.Mappers;
using Emulator.Models;
using Emulator.ViewModels.Base;
using Emulator.ViewModels.Helpers;

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
        /// Источник данных предоставляющий выбор количества столбцов в сетке
        /// </summary>
        //private readonly List<int> _columnsSource;

        /// <summary>
        /// Список команд выполняемых роботом
        /// </summary>
        private readonly ObservableCollection<CommandModel> _commandList;

        /// <summary>
        /// Количество строк в сетке
        /// </summary>
        private int _rowCount;

        /// <summary>
        /// Количество столбцов в сетке
        /// </summary>
        private int _columnCount;

        #region Для команд

        /// <summary>
        /// Поле для команды добавления команды инициализации в список команд
        /// </summary>
        private BaseCommandRelay _addInicializationCommandInList;

        #endregion

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
                    RowGenerator.Initialize(RowPointsSource, 0, value, 1);
                    RowPoint = RowPointsSource[0];
                    OnPropertyChanged(nameof(RowPoint));
                }
            } 
        }

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
                    RowGenerator.Initialize(ColumnPointsSource, 0, value, 1);
                    ColumnPoint = ColumnPointsSource[0];
                    OnPropertyChanged(nameof(ColumnPoint));
                }
            }
        }

        /// <summary>
        /// Начальное положение робота (столбец)
        /// </summary>
        public int RowPoint { get; set; }

        /// <summary>
        /// Начальное положение робота (столбец)
        /// </summary>
        public int ColumnPoint { get; set; }

        /// <summary>
        /// Номер следующий команды
        /// </summary>
        public int NextCommandNumber { get; set; }

        /// <summary>
        /// Источник для выбора количества строк в сетке
        /// </summary>
        public List<int> RowsSource { get; }

        /// <summary>
        /// Источник для выбора количества столбцов
        /// </summary>
        public List<int> ColumnsSource { get; }
        
        /// <summary>
        /// Источник номеров команд для выбора номера следующей команды
        /// </summary>
        public List<int> NextCommandSource { get; set; }

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
        /// <param name="commandList">список команд выполняемых роботом</param>
        /// </summary>
        public InitializationViewModel(ObservableCollection<CommandModel> commandList)
        {
            _commandList = commandList;

            RowsSource = new List<int>(); RowGenerator.Initialize(RowsSource, 10, 100, 1);
            ColumnsSource = new List<int>(); RowGenerator.Initialize(ColumnsSource, 10, 100, 1);
            RowPointsSource = new ObservableCollection<int>();
            ColumnPointsSource = new ObservableCollection<int>();

            NextCommandNumber = 1;
            NextCommandSource = new List<int> {0, 1};
        }

        #endregion

        #region Команды 

        /// <summary>
        /// Команда инициализации сетки для робота
        /// </summary>
        public BaseCommandRelay AddInicializationCommandInList => 
            _addInicializationCommandInList ?? (_addInicializationCommandInList = new BaseCommandRelay(AddInicializationCommand));

        #region Методы для команд

        /// <summary>
        /// Метод добавляющий строку команды инициализации в список выполняемых команд
        /// </summary>
        /// <param name="obj"></param>
        private void AddInicializationCommand()
        {
            _commandList.Clear();

            var initializeCommandModel = new InitializeCommandModel
            {
                RowCount = RowCount,
                ColumnCount = ColumnCount,
                RowPoint = RowPoint,
                ColumnPoint = ColumnPoint,
                NextCommandNumber = NextCommandNumber
            };

            _commandList.Add(ListModelMapper.GetCommand(initializeCommandModel));
        }

        #endregion 

        #endregion
    }
}