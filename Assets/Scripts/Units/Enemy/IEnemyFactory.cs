using Enum;
using UnityEngine;


namespace Units.Enemy
{
    public interface IEnemyFactory
    {
        IEnemy CreateEnemy(EnemyType type, Vector3 point);
    }
}