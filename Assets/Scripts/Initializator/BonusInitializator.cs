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
                coin.name = gameObject.name;
                // coins.Add(coin);
            }
        }
    }
}