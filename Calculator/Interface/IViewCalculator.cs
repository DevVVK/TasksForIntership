using System;

namespace Calculator.Interface
{
    /// <summary>
    /// Интервейс представляющий представление
    /// </summary>
    public interface IViewCalculator
    {
        event EventHandler<CommandPressedEventArgs> CommandPressed;

        string Expression { set; get; }

        string Output { set; get; }
    }
} 