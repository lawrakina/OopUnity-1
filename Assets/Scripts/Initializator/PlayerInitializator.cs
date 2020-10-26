using Controller;
using Data;
using Model;
using UnityEngine;
using View;


namespace Initializator
{
    public static class PlayerInitializator
    {
        public static PlayerController GetController(PlayerData playerData, UserInput userInputVector)
        {
            var spawnerPlayer = Object.Instantiate(playerData.PlayerStruct.StoragePlayer,
                playerData.PlayerStruct.StartPosition,
                Quaternion.identity);

            var playerModel = new PlayerModel()
            {
                Speed = playerData.PlayerStruct.Speed,
            };

            var playerView = spawnerPlayer.GetComponent<PlayerView>();
            playerData.PlayerStruct.Player = playerView.gameObject;

            return new PlayerController(playerView, playerModel, userInputVector);
        }
    }
}