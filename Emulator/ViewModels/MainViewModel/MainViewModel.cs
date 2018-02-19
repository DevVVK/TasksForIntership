using System.Windows.Controls;
using Emulator.Interpreters;
using Emulator.ViewModels.Base;

namespace Emulator.ViewModels.MainViewModel
{
    /// <summary>
    /// Класс представляющий модель-представления эмулятора среды разработки и выполнения алгоритма для робота
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        #region Открытые свойства

        /// <summary>
        /// Свойство представляющее объект управления командой инициализации сетки
        /// </summary>
        public InitializationViewModel InitializationGridFields { get; }

        /// <summary>
        /// Свойство представляющее объект команды запуска выполнения списка команд
        /// </summary>
        public CommandListManagerViewModel CommandListManager { get; }

        /// <summary>
        /// Свойство для объекта выгрузки алгоритма в файл и загрузки алгоритма из файла
        /// </summary>
        public FileManagerViewModel FileManager { get; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MainViewModel(Grid visualGrid)
        {
            var commandInterpreter = new CommandInterpreter(visualGrid);
            InitializationGridFields = new InitializationViewModel(commandInterpreter);
            CommandListManager = new CommandListManagerViewModel(commandInterpreter);
            FileManager = new FileManagerViewModel(commandInterpreter); 
        }

        #endregion
    }
}