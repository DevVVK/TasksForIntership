using RobotObjects.Enumerables;

namespace Emulator.Models
{
    /// <summary>
    /// Класс представляющий модель команды заливки ячейки
    /// </summary>
    public class PouringCellCommandModel
    {
        #region Открытые свойства

        /// <summary>
        /// Идентификатор команды
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Цвет, которым необходимо закрасить ячейку
        /// </summary>
        public ColorCell CellColor { get; set; }

        /// <summary>
        /// Идентификатор следующий команды
        /// </summary>
        public int NextCommandId { get; set; }

        #endregion
    }
}