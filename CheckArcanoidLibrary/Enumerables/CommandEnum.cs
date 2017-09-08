using System.Windows.Forms;
using CheckArcanoidLibrary.Attributes;

namespace CheckArcanoidLibrary.Enumerables
{
    public enum CommandEnum
    {
        [CommandEventArgs(Keys.Space)]
        StartGame,

        [CommandEventArgs(Keys.P)]
        PauseGame,

        ShowStatistic,

        Replay,

        Initialize,

        ReturnMainForm,

        CloseGame
    }
}