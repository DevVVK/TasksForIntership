using System.Collections.ObjectModel;
using System.Windows.Input;
using Robot.Models;
using Robot.ViewModels.Base;

namespace Robot.ViewModels
{
    /// <summary>
    /// Класс представляющий модель-представления эмулятора среды разработки и выполнения алгоритма для робота
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        #region Закрытые поля

        #endregion

        #region Открытые свойства

        /// <summary>
        /// Список выполняемых команд
        /// </summary>
        public ObservableCollection<CommandModel> CommandList { get; }

        /// <summary>
        /// Свойство представляющее объект управления командой инициализации сетки
        /// </summary>
        public InitializationViewModel InitializationGridFields { get; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MainViewModel()
        {
            CommandList = new ObservableCollection<CommandModel>();

            InitializationGridFields = new InitializationViewModel();
        }

        #endregion

        #region Команды 

        /// <summary>
        /// Команда запускающая исполнение список команд
        /// </summary>
        public ICommand StartEmulation { get; }

        /// <summary>
        /// Команда запускающая пошаговое выполнение списка команд
        /// </summary>
        public ICommand StartStepEmulation { get; }

        /// <summary>
        /// Команда очищающая список команд
        /// </summary>
        public ICommand ClearListCommand { get; }

        /// <summary>
        /// Команда сохраняющая алгоритм в файл
        /// </summary>
        public ICommand SaveToFile { get; }

        /// <summary>
        /// Команда окрывающия алгоритм из файла
        /// </summary>
        public ICommand OpenFile { get; }

        #endregion
    }
}