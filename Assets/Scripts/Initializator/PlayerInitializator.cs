using Controller;
using Data;
using Model;
using UnityEngine;
using View;


namespace Initializator
{
    public sealed class PlayerInitializator
    {
        public PlayerInitializator(MainController mainController, PlayerData playerData, InputStruct inputVector)
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

            var controller = new PlayerController(playerView, playerModel, inputVector);
            mainController.AddUpdated(controller);
        }
    }
}