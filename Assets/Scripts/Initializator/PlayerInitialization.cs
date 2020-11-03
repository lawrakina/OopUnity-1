using Interface;
using UnityEngine;


namespace Initializator
{
    public sealed class PlayerInitialization : IInitialization
    {
        private readonly IPlayerFactory _playerFactory;
        private          Transform      _player;

        public PlayerInitialization(IPlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
            _player = _playerFactory.CreatePlayer();
        }
        
        public void Initialization()
        {
        }

        public Transform GetPlayer()
        {
            return _player;
        }
    }
}