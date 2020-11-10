using System;
using System.Collections.Generic;
using System.Linq;
using Enum;
using Units.Enemy;
using UnityEngine;


namespace Data
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Data/EnemyData")]
    public sealed class EnemyData : ScriptableObject
    {
        [Serializable]
        public struct EnemyInfo
        {
            public EnemyType     Type;
            public EnemyProvider EnemyPrefab;
            public int           Coint;
        }

        [SerializeField] private List<EnemyInfo> _enemyInfos;

        public EnemyProvider GetEnemy(EnemyType type)
        {
            var enemyInfo = _enemyInfos.First(info => info.Type == type);
            return enemyInfo.EnemyPrefab;
        }

        public List<EnemyInfo> GetListEnemies()
        {
            return _enemyInfos;
        }
    }
}