using System.Collections.Generic;
using Data;
using UnityEngine;


namespace Initializator
{
    internal class BonusInitializator
    {
        public BonusInitializator(GameData gameData)
        {
            var gameStruct = gameData.GameStruct;
            // var coins = new List<GameObject>();
            for (int i = 0; i < gameStruct.CountCreateCoints; i++)
            {
                var coin = Object.Instantiate(gameStruct.StorageCoin,
                    GeneratePoint(gameStruct.PointZero, gameStruct.Lenght, gameStruct.Widht),
                    Quaternion.identity);
                // coins.Add(coin);
            }
        }

        private Vector3 GeneratePoint(Vector2 startPosition, float lenght, float widht)
        {
            return new Vector3(
                Random.Range(startPosition.x - (lenght / 2), startPosition.x + (lenght / 2)),
                1.0f,
                Random.Range(startPosition.y - (widht / 2), startPosition.y + (widht / 2))
            );
        }
    }
}