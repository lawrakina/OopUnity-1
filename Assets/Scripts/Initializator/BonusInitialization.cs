using System;
using System.Collections.Generic;
using Bonus;
using Interface;
using UnityEngine;


namespace Initializator
{
    public sealed class BonusInitialization: IInitialization
    {
        #region fields

        private readonly BonusFactory    _bonusFactory;
        private readonly TerrainManager  _terrainManager;
        private          List<Transform> _listBonuses = new List<Transform>();

        #endregion


        #region ctor

        public BonusInitialization(BonusFactory bonusFactory, TerrainManager terrainManager)
        {
            _bonusFactory = bonusFactory;
            _terrainManager = terrainManager;

            InstantiateBonus(_bonusFactory.CreateCoins, _bonusFactory.CountCoins);
            InstantiateBonus(_bonusFactory.CreateBomb, _bonusFactory.CountBombs);
            InstantiateBonus(_bonusFactory.CreateImmunity, _bonusFactory.CountImmunity);
            InstantiateBonus(_bonusFactory.CreateLive, _bonusFactory.CountExtraLive);
            InstantiateBonus(_bonusFactory.CreateSpeedUp, _bonusFactory.CountSpeedUp);
        }
        
        public void Initialization()
        {
            
        }

        #endregion


        #region privateMethods

        private void InstantiateBonus(Func<Transform> createFromFactory, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var item = createFromFactory();
                item.position = _terrainManager.GeneratePoint();
                _listBonuses.Add(item);
            }
        }

        #endregion

    }
}