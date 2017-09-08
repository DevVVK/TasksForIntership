using CheckArcanoidLibrary.Logic;

namespace CheckArcanoidLibrary.Models
{
    public class GameModel
    {
        private GameLoop _gameLoop;

        public GameModel()
        {}

        public void AddGameLoop(GameLoop gameLoop)
        {
            _gameLoop = gameLoop;
        }

        public GameLoop GetGameLoop()
        {
            return _gameLoop;
        }
    }
}