using Data;
using Enum;
using Interface;
using Model;


namespace Initializator
{
    public sealed class GameStateInitialization : IInitialization
    {
        #region Fields

        private GameData                       _gameData;
        private PlayerData                     _playerData;
        private IGameStateNotifyPropertyChange _gameState;

        #endregion

        public GameStateInitialization(GameData gameData, PlayerData playerData)
        {
            _gameData = gameData;
            _playerData = playerData;
            _gameState = new GameStateNotifyPropertyChange(GameState.Menu);
        }

        public void Initialization()
        {
        }

        public IGameStateNotifyPropertyChange GetGameState()
        {
            return _gameState;
        }
    }
}