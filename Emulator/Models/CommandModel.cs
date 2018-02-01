namespace Emulator.Models
{
    /// <summary>
    /// Класс представляющий модель команды для списка выполняющихся команд
    /// </summary>
    public class CommandModel
    {
        #region Открытые свойства

        /// <summary>
        /// Номер команды
        /// </summary>
        public int CommandId { get; set; }

        /// <summary>
        /// Назваение команды 
        /// </summary>
        public string CommandName { get; set; }

        /// <summary>
        /// Первый параметр команды 
        /// </summary>
        public string OneParameter { get; set; }

        /// <summary>
        /// Второй параметр команды 
        /// </summary>
        public string TwoParameter { get; set; }

        #endregion
    }
}