using System.Collections.Generic;
using Data;
using Interface;
using Units.Enemy;

namespace Initializator
{
    public sealed class EnemyInitialization : IInitialization
    {
        #region Fields

        private EnemyFactory   _enemyFactory;
        private EnemyData      _enemyData;
        private TerrainManager _terrainManager;
        private List<IEnemy>   _enemies = new List<IEnemy>();

        #endregion

        public EnemyInitialization(EnemyFactory enemyFactory, EnemyData enemyData, TerrainManager terrainManager)
        {
            _enemyFactory = enemyFactory;
            _enemyData = enemyData;
            _terrainManager = terrainManager;

            InstantiateEnemy();
        }

        private void InstantiateEnemy()
        {
            foreach (var item in _enemyData.GetListEnemies())
            {
                for (var i = 0; i < item.Coint; i++)
                {
                    _enemies.Add(_enemyFactory.CreateEnemy(item.Type, _terrainManager.GeneratePoint()));
                }
            }
        }

        public void Initialization()
        {
            
        }

        public List<IEnemy> GetEnemies()
        {
            return _enemies;
        }
    }
}