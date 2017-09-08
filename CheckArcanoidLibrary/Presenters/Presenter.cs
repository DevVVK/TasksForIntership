using System.Windows.Forms;
using CheckArcanoidLibrary.Enumerables;
using CheckArcanoidLibrary.Interfaces;
using CheckArcanoidLibrary.Logic;
using CheckArcanoidLibrary.Models;

namespace CheckArcanoidLibrary.Presenters
{
    public abstract class Presenter
    {
        private readonly ControlViewsModel _model;

        private readonly Control _mainForm;

        private static GameModel _gameModel;

        protected Presenter(IViewArcanoid view, ControlViewsModel model, GameModel gameModel)
        {
            _model = model;

            _mainForm = _model.GetControl(NameControlEnum.MainForm);

            _gameModel = gameModel;

            view.CommandGameKeyPress += ViewOnCommandGameKeyPress;
        }

        protected abstract void ViewOnCommandGameKeyPress(object sender, CommandArgs commandArgs);

        #region Работа с моделью

        /// <summary>
        /// Удаляет форму из модели
        /// </summary>
        /// <param name="removedControl">имя удаляемой формы</param>
        protected void RemoveInModel(NameControlEnum removedControl)
        {
            _model.Remove(removedControl);
        }

        /// <summary>
        /// Добавляет форму в модель
        /// </summary>
        /// <param name="nameAddControl">имя добавляемой формы</param>
        /// <param name="control">ссылка на форму</param>
        protected void AddControlInModel(NameControlEnum nameAddControl, Control control)
        {
            _model.AddControl(nameAddControl, control);
        }

        /// <summary>
        /// Получает форму из модели
        /// </summary>
        /// <param name="additiongControl">имя получаемой формы</param>
        /// <returns>форма из модели</returns>
        protected Control GetControl(NameControlEnum additiongControl)
        {
            return _model.GetControl(additiongControl);
        }

        #endregion

        #region Работа с главной формой

        /// <summary>
        /// Добавляет форму из модели в главную форму 
        /// </summary>
        /// <param name="nameAddControl">имя добавляемой формы</param>
        protected void AddMainForm(NameControlEnum nameAddControl)
        {
            _mainForm.Controls.Add(GetControl(nameAddControl));
        }

        /// <summary>
        /// Удаляет форму из главной формы
        /// </summary>
        /// <param name="nameRemoveControl">имя удаляемой формы</param>
        protected void RemoveMainForm(NameControlEnum nameRemoveControl)
        {
            _mainForm.Controls.Remove(GetControl(nameRemoveControl));
        }

        /// <summary>
        /// Проверяет содержится ли данная форма на главной форме
        /// </summary>
        /// <param name="nameControl">проверяемая форма</param>
        /// <returns>если форма содержится true иначе false</returns>
        protected bool ContainsMainForm(NameControlEnum nameControl)
        {
            return _mainForm.Contains(GetControl(nameControl));
        }

        #endregion

        #region Работа с игрой

        private readonly KeyListener _keyListener = new KeyListener();

        /// <summary>
        /// Создает новую игру и добавляет ее в модель
        /// </summary>
        protected virtual void CreateNewGame()
        {
            var gameInterface = GetControl(NameControlEnum.GameInterface);
            gameInterface.Controls.Clear();

            gameInterface.PreviewKeyDown += _keyListener.PreviewKeyDown;
            gameInterface.KeyUp += _keyListener.KeyUp;

            var gameLoop = new GameLoop(gameInterface, 15, 5, _keyListener);
            _gameModel.AddGameLoop(gameLoop);
        }

        /// <summary>
        /// Начать игру
        /// </summary>
        protected void StartGame()
        {
            _gameModel.GetGameLoop().StartGame();
        }

        /// <summary>
        /// Пауза игры
        /// </summary>
        protected void PauseGame()
        {
            _gameModel.GetGameLoop().Pause();
        }

        #endregion
    }
}