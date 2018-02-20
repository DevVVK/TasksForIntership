namespace Emulator.Models
{
    /// <summary>
    /// Класс предсавляющий модель команды движения 
    /// </summary>
    public class MoveCommandModel
    {
        #region Открытые свойства

        /// <summary>
        /// Идентификатор команды
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Количество клеток на которое нужно переместить робота
        /// </summary>
        public int CellCount { get; set; }

        /// <summary>
        /// Идентификатор следующей команды
        /// </summary>
        public int NextCommandNumber { get; set; }

        #endregion
    }
}