using System;
using System.Windows.Forms;
using CheckArcanoidLibrary.Enumerables;
using CheckArcanoidLibrary.Forms;
using CheckArcanoidLibrary.Models;
using CheckArcanoidLibrary.Presenters;

namespace CheckArcanoidLibrary
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var arcanoidMainForm = new ArcanoidMainForm();
            var mainPanel = new MainPanel();
            var pausePanel = new PausePanel();
            var gamePanel = new GamePanel();

            var controlViewsModel = new ControlViewsModel();
            var gameModel = new GameModel();

            controlViewsModel.AddControl(NameControlEnum.MainForm, arcanoidMainForm);
            controlViewsModel.AddControl(NameControlEnum.GameInterface, gamePanel);
            controlViewsModel.AddControl(NameControlEnum.PauseInterface, pausePanel);
            controlViewsModel.AddControl(NameControlEnum.MainInterface, mainPanel);

            var mainIntefacePresetner = new MainInterfacePresenter(mainPanel, controlViewsModel, gameModel);
            var pauseInterfacePresenter = new PauseInterfacePresenter(pausePanel, controlViewsModel, gameModel);
            var gameInterfacePresenter = new GameInterfacePresenter(gamePanel, controlViewsModel, gameModel);

            arcanoidMainForm.Controls.Add(mainPanel);

            Application.Run(arcanoidMainForm);
        }
    }
}
