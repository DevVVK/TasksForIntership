using System.ComponentModel;
using RobotObjects.Enumerables;

namespace Emulator.Models
{
    /// <summary>
    /// Класс представляющий модель команды заливки ячейки
    /// </summary>
    [Description("Заливка")]
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