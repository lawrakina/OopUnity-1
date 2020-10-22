using Controller;
using Data;
using Model;
using UnityEngine;
using View;


namespace Initializator
{
    public sealed class PlayerInitializator
    {
        public PlayerInitializator(Services services, GameContext gameContext)
        {
            var spawnerPlayer = Object.Instantiate(gameContext.PlayerData.PlayerStruct.StoragePlayer,
                gameContext.PlayerData.PlayerStruct.StartPosition,
                Quaternion.identity);

            var playerModel = new PlayerModel()
            {
                Speed = gameContext.PlayerData.PlayerStruct.Speed,
            };

            var playerView = spawnerPlayer.GetComponent<PlayerView>();
            gameContext.PlayerData.PlayerStruct.Player = playerView.gameObject;

            services.PlayerController = new PlayerController(services, gameContext, playerView, playerModel);
        }
    }
}