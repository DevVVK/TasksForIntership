using System.Windows.Forms;

namespace CheckArcanoidLibrary.Interfaces
{
    public interface IView : IViewArcanoid
    {
        Control ControlLink { get; }
    }
}