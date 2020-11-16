using System.Collections.Generic;
using Units.Enemy;


namespace Model
{
    public sealed class EnemiesModel
    {
        private List<IEnemy> _enemies;

        public EnemiesModel(List<IEnemy> enemies)
        {
            _enemies = enemies;
        }
    }
}