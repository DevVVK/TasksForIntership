using System.ComponentModel;

namespace RobotObjects.Enumerables
{
    /// <summary>
    /// Направление поворота
    /// </summary>
    public enum RouteMove
    {
        /// <summary>
        /// Направление влево
        /// </summary>
        [Description("Налево")]
        Left, 

        /// <summary>
        /// Направление вправо
        /// </summary>
        [Description("Направо")]
        Right,

        /// <summary>
        /// Направление вверх
        /// </summary>
        Top, 

        /// <summary>
        /// Направление вниз
        /// </summary>
        Bottom
    }
}