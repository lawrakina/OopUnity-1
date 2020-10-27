using Data;
using UnityEngine;


namespace Initializator
{
    internal sealed class BonusInitializator
    {
        private GameStruct gameStruct;
        public BonusInitializator(GameData gameData)
        {
            gameStruct = gameData.GameStruct;

            InstantiateBonus(gameStruct.StorageCoin, gameStruct.createCountCoins);
            InstantiateBonus(gameStruct.StorageBonusSpeedUp, gameStruct.createCountBonusSpeedUp);
            InstantiateBonus(gameStruct.StorageBonusImmunity, gameStruct.createCountBonusImmunity);
            InstantiateBonus(gameStruct.StorageBonusBomb, gameStruct.createCountBonusBomb);
            // var coins = new List<GameObject>();
            // for (int i = 0; i < gameStruct.createCountCoins; i++)
            // {
            //     var coin = Object.Instantiate(gameStruct.StorageCoin,
            //         GeneratePoint(gameStruct.PointZero, gameStruct.Lenght, gameStruct.Widht),
            //         Quaternion.identity);
            //     // coins.Add(coin);
            // }

            // for (int i = 0; i < gameStruct.createBonusSpeedUp; i++)
            // {
            //     Object.Instantiate(gameStruct.StorageBonusSpeedUp,
            //         GeneratePoint(gameStruct.PointZero, gameStruct.Lenght, gameStruct.Widht),
            //         Quaternion.identity);
            // }
            //
            // for (int i = 0; i < gameStruct.createBonusImmunity; i++)
            // {
            //     Object.Instantiate(gameStruct.StorageBonusImmunity,
            //         GeneratePoint(gameStruct.PointZero, gameStruct.Lenght, gameStruct.Widht),
            //         Quaternion.identity);
            // }
            //
            // for (int i = 0; i < gameStruct.createBonusBomb; i++)
            // {
            //     Object.Instantiate(gameStruct.StorageBonusBomb,
            //         GeneratePoint(gameStruct.PointZero, gameStruct.Lenght, gameStruct.Widht),
            //         Quaternion.identity);
            // }
        }

        private Vector3 GeneratePoint(Vector2 startPosition, float lenght, float widht)
        {
            return new Vector3(
                Random.Range(startPosition.x - (lenght / 2), startPosition.x + (lenght / 2)),
                1.0f,
                Random.Range(startPosition.y - (widht / 2), startPosition.y + (widht / 2))
            );
        }

        private void InstantiateBonus(GameObject gameObject, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var coin = Object.Instantiate(gameObject,
                    GeneratePoint(gameStruct.PointZero, gameStruct.Lenght, gameStruct.Widht),
                    Quaternion.identity);
                // coins.Add(coin);
            }
        }
    }
}