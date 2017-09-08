using CheckArcanoidLibrary.Enumerables;
using CheckArcanoidLibrary.Interfaces;
using CheckArcanoidLibrary.Models;

namespace CheckArcanoidLibrary.Presenters
{
    public class PauseInterfacePresenter : Presenter
    {
        public PauseInterfacePresenter(IViewArcanoid view, ControlViewsModel model, GameModel gameModel) : base(view, model, gameModel)
        { }

        protected override void ViewOnCommandGameKeyPress(object sender, CommandArgs e)
        {
            if (e.Command == CommandEnum.Replay)
            {
                CreateNewGame();
                AddMainForm(NameControlEnum.GameInterface);
                RemoveMainForm(NameControlEnum.PauseInterface);
            }

            if (e.Command == CommandEnum.StartGame)
            {
                AddMainForm(NameControlEnum.GameInterface);
                RemoveMainForm(NameControlEnum.PauseInterface);
            }

            if (e.Command != CommandEnum.ReturnMainForm) return;

            AddMainForm(NameControlEnum.MainInterface);
            RemoveMainForm(NameControlEnum.GameInterface);
            RemoveMainForm(NameControlEnum.PauseInterface);
        }
    }
}