using System.ComponentModel;

namespace RobotObjects.Enumerables
{
    /// <summary>
    /// Цвет ячейки сетки, по которой передвигается робот
    /// </summary>
    public enum ColorCell
    {
        /// <summary>
        /// Белый цвет
        /// </summary>
        [Description("Белый")]
        White,

        /// <summary>
        /// Черный цвет
        /// </summary>
        [Description("Черный")]
        Black
    }
}