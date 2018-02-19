using System.ComponentModel;

namespace Emulator.ViewModels.Enumerables
{
    /// <summary>
    /// Перечисление имен команд
    /// </summary>
    public enum CommandName
    {
        [Description("Движение")]
        Move,

        [Description("Изучение")]
        Learn,
        
        [Description("Заливка")]
        Pouring,

        [Description("Поворот")]
        Rotation
    }
}