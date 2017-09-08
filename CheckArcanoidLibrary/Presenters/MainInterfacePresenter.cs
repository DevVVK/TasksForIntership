using CheckArcanoidLibrary.Enumerables;
using CheckArcanoidLibrary.Interfaces;
using CheckArcanoidLibrary.Models;

namespace CheckArcanoidLibrary.Presenters
{
    public class MainInterfacePresenter : Presenter
    {
        public MainInterfacePresenter(IViewArcanoid view, ControlViewsModel model, GameModel gameModel) : base(view, model, gameModel)
        { }

        protected override void ViewOnCommandGameKeyPress(object sender, CommandArgs e)
        {
            if (e.Command != CommandEnum.StartGame) return;

            CreateNewGame();
            AddMainForm(NameControlEnum.GameInterface);
            RemoveMainForm(NameControlEnum.MainInterface);
        }
    }
}