using Data;
using Interface;
using Units.Player;


namespace Initializator
{
    public sealed class PlayerInitialization : IInitialization
    {
        private readonly IPlayerFactory             _playerFactory;
        private          PlayerData                 _playerData;
        private          IPlayerView                _player;
        private          IFloatNotifyPropertyChange _speedPlayer;

        public PlayerInitialization(IPlayerFactory playerFactory, PlayerData playerData)
        {
            _playerFactory = playerFactory;
            _playerData = playerData;
            _player = _playerFactory.CreatePlayer();
            _speedPlayer = _playerData.Speed;
        }

        public void Initialization()
        {
        }

        public IPlayerView GetPlayer()
        {
            return _player;
        }

        public IFloatNotifyPropertyChange GetPlayerSpeed()
        {
            return _speedPlayer;
        }
    }
}