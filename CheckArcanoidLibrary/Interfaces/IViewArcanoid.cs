using System;

namespace CheckArcanoidLibrary.Interfaces
{
    public interface IViewArcanoid
    {
        event EventHandler<CommandArgs> CommandGameKeyPress;
    }
}