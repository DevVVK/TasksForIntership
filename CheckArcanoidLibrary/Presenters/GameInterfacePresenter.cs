using CheckArcanoidLibrary.Enumerables;
using CheckArcanoidLibrary.Interfaces;
using CheckArcanoidLibrary.Models;

namespace CheckArcanoidLibrary.Presenters
{
    public class GameInterfacePresenter : Presenter
    {
        public GameInterfacePresenter(IViewArcanoid view, ControlViewsModel model, GameModel gameModel) : base(view, model, gameModel)
        {}

        protected override void ViewOnCommandGameKeyPress(object sender, CommandArgs e)
        {
            if (e.Command == CommandEnum.StartGame)
            {
                StartGame();
            }

            if (e.Command != CommandEnum.PauseGame) return;

            PauseGame();
            RemoveMainForm(NameControlEnum.GameInterface);
            AddMainForm(NameControlEnum.PauseInterface);
        }
    }
}