using Controller;
using Data;
using Model;
using UnityEngine;
using View;


namespace Initializator
{
    public class PlayerInitializator
    {
        public PlayerInitializator(MainController mainController, GameData gameData, PlayerData playerData,
            UserInput userInputVector)
        {
            var spawnerPlayer = Object.Instantiate(playerData.PlayerStruct.StoragePlayer,
                playerData.PlayerStruct.StartPosition,
                Quaternion.identity);

            var playerModel = new PlayerModel()
            {
                Live = gameData.GameStruct.CountLive,
                CountCoins = gameData.GameStruct.CountCoins,
                Speed = playerData.PlayerStruct.Speed,
            };

            var playerView = spawnerPlayer.GetComponent<PlayerView>();
            playerData.PlayerStruct.Player = playerView.gameObject;

            var controller = new PlayerController(playerView, playerModel, userInputVector);
            
            mainController.AddEnabled(controller);// OnEnable and OnDisable
            mainController.AddUpdated(controller);// Update
            mainController.AddFixedUpdated(controller);//FixedUpdate
        }
    }
}