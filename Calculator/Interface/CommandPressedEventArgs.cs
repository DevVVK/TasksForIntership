using System;
using Calculator.Enumerables;

namespace Calculator.Interface
{
    /// <summary>
    /// Реализация класса для хранения нажатой команды(операции)
    /// </summary>
    public class CommandPressedEventArgs : EventArgs
    {
        public OperatorEnum Command { get; }

        public CommandPressedEventArgs(OperatorEnum command)
        {
            Command = command;
        }
    }
}