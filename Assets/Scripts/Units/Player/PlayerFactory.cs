using Data;
using Extension;
using Interface;
using Model;
using UnityEngine;
using View;


namespace Units.Player
{
    public sealed class PlayerFactory: IPlayerFactory
    {
        #region fields

        private readonly PlayerData _playerData;

        #endregion


        #region ctor

        public PlayerFactory(PlayerData playerData)
        {
            _playerData = playerData;
            //костыль!!! Не знаю как исправить
            _playerData.Speed = new FloatNotifyPropertyChange(_playerData._speed);
        }

        #endregion

        
        public IPlayerView CreatePlayer()
        {
            var player = Object.Instantiate(_playerData.StoragePlayer);
            player.name = $"Player";
            player.AddSphereCollider(radius: 0.5f, isTrigger: false)
                .AddRigitBody(mass: 1, CollisionDetectionMode.Continuous, isKinematic:false)
                .AddCode<PlayerView>();
            return player.GetComponent<IPlayerView>();
        }
    }
}