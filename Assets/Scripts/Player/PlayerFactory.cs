using Data;
using Extension;
using Interface;
using UnityEngine;
using View;


namespace Player
{
    internal sealed class PlayerFactory: IPlayerFactory
    {
        private readonly PlayerData _playerData;

        public PlayerFactory(PlayerData playerData)
        {
            _playerData = playerData;
        }

        public Transform CreatePlayer()
        {
            var player = Object.Instantiate(_playerData.PlayerStruct.StoragePlayer);
            player.name = $"Player";
            player.AddSphereCollider(radius:0.5f)
                .AddRigitBody(mass: 1, CollisionDetectionMode.Continuous)
                .AddCode<PlayerView>();
            return player.transform;
        }
    }
}