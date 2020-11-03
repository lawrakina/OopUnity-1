using Interface;
using Units.Player;
using UnityEngine;


namespace Initializator
{
    public sealed class PlayerInitialization : IInitialization
    {
        private readonly IPlayerFactory _playerFactory;
        private          IPlayerView _player;

        public PlayerInitialization(IPlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
            _player = _playerFactory.CreatePlayer();
        }
        
        public void Initialization()
        {
        }

        public IPlayerView GetPlayer()
        {
            return _player;
        }
    }
}