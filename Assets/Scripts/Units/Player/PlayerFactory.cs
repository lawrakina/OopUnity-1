using Data;
using Extension;
using Interface;
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
        }

        #endregion

        
        public Transform CreatePlayer()
        {
            var player = Object.Instantiate(_playerData.StoragePlayer);
            player.name = $"Player";
            player.AddSphereCollider(radius:0.5f)
                .AddRigitBody(mass: 1, CollisionDetectionMode.Continuous)
                .AddCode<PlayerView>();
            return player.transform;
        }
    }
}