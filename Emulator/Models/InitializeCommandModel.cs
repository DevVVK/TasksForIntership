namespace Emulator.Models
{
    /// <summary>
    /// Класс модели для команды инициализации робота 
    /// </summary>
    public class InitializeCommandModel
    {
        #region Открытые свойства

        /// <summary>
        /// Идентификатор команды
        /// </summary>
        public int Id;

        /// <summary>
        /// Количество строк
        /// </summary>
        public int RowCount { get; set; }

        /// <summary>
        /// Количество столбцов
        /// </summary>
        public int ColumnCount { get; set; }

        /// <summary>
        /// Индекс строки где должен находится робот
        /// </summary>
        public int RowPoint { get; set; }

        /// <summary>
        /// Индекс столбца где должен находится робот
        /// </summary>
        public int ColumnPoint { get; set; }

        /// <summary>
        /// Номер следующей команды
        /// </summary>
        public int NextCommandNumber { get; set; }

        #endregion
    }
}