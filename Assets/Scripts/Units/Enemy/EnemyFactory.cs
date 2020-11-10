using Data;
using Enum;
using UnityEngine;


namespace Units.Enemy
{
    public sealed class EnemyFactory : IEnemyFactory
    {
        #region fields

        private readonly EnemyData _enemyData;

        #endregion

        public EnemyFactory(EnemyData enemyData)
        {
            _enemyData = enemyData;
        }

        public IEnemy CreateEnemy(EnemyType type, Vector3 point)
        {
            var enemyProvider = _enemyData.GetEnemy(type);
            return Object.Instantiate(enemyProvider, point, Quaternion.identity);
        }
    }
}