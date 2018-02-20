namespace Emulator.Models
{
    /// <summary>
    /// Класс представляющий модель команды изучения ячейки 
    /// </summary>
    public class LearnCellCommandModel
    {
        #region Открытые свойства

        /// <summary>
        /// Идентификатор команды
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор команды, если цвет ячейки белый 
        /// </summary>
        public int CommandIdIfCellColorWhite { get; set; }

        /// <summary>
        /// Идентификатор команды, если цвет ячейки черный 
        /// </summary>
        public int CommandIdIfCellColorBlack { get; set; }

        #endregion
    }
}