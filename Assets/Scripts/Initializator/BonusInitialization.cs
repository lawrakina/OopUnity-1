using System;
using System.Collections.Generic;
using Bonus;
using Interface;
using UnityEngine;
using View;


namespace Initializator
{
    public sealed class BonusInitialization: IInitialization
    {
        #region fields

        private readonly BonusFactory    _bonusFactory;
        private readonly TerrainManager  _terrainManager;
        private          List<BonusView> _listBonuses = new List<BonusView>();

        #endregion


        #region ctor

        public BonusInitialization(BonusFactory bonusFactory, TerrainManager terrainManager)
        {
            _bonusFactory = bonusFactory;
            _terrainManager = terrainManager;

            InstantiateBonus(() => _bonusFactory.CreateCoins(), _bonusFactory.CountCoins);
            InstantiateBonus(() => _bonusFactory.CreateBomb(), _bonusFactory.CountBombs);
            InstantiateBonus(() => _bonusFactory.CreateImmunity(), _bonusFactory.CountImmunity);
            InstantiateBonus(() => _bonusFactory.CreateLive(), _bonusFactory.CountExtraLive);
            InstantiateBonus(() => _bonusFactory.CreateSpeedUp(), _bonusFactory.CountSpeedUp);
        }
        
        public void Initialization()
        {
            
        }

        #endregion


        #region privateMethods

        private void InstantiateBonus(Func<BonusView> createFromFactory, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var item = createFromFactory();
                item.transform.position = _terrainManager.GeneratePoint();
                _listBonuses.Add(item);
            }
        }

        #endregion

        public List<BonusView> AllBonuses()
        {
            return _listBonuses;
        }
    }
}