using RobotObjects.Enumerables;

namespace Emulator.Models
{
    /// <summary>
    /// Класс представляющий модель команды поворота робота
    /// </summary>
    public class RotationCommandModel
    {
        #region Открытые свойства

        /// <summary>
        /// Идентификатор команды
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Направление движения робота
        /// </summary>
        public RouteMove Route { get; set; }

        /// <summary>
        /// Идентификатор следующей команды
        /// </summary>
        public int NextCommandId { get; set; }

        #endregion 
    }
}