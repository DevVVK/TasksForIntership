using CheckArcanoidLibrary.Enumerables;

namespace CheckArcanoidLibrary.Interfaces
{
    public class CommandArgs
    {
        public CommandEnum Command { get; set; }

        public CommandArgs(CommandEnum command)
        {
            Command = command;
        }
    }
}