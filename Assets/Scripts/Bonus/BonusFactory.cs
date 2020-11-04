using Data;
using Enum;
using Extension;
using Interface;
using UnityEngine;


namespace Bonus
{
    public sealed class BonusFactory : IBonusFactory
    {
        #region fields

        private readonly BonusData _bonusData;

        #endregion


        #region Properties

        public int CountCoins     => _bonusData.BonusStruct.createCountCoins;
        public int CountBombs     => _bonusData.BonusStruct.createCountBonusBomb;
        public int CountImmunity  => _bonusData.BonusStruct.createCountBonusImmunity;
        public int CountSpeedUp   => _bonusData.BonusStruct.createCountBonusSpeedUp;
        public int CountExtraLive => _bonusData.BonusStruct.createExtraLive;

        #endregion


        #region ctor

        public BonusFactory(BonusData bonusData)
        {
            _bonusData = bonusData;
        }

        #endregion


        #region Methods

        public Transform CreateCoins()
        {
            return CreateBonus(_bonusData.BonusStruct.StorageCoin, InteractiveObjectType.Coin, 1).transform;
        }

        public Transform CreateLive()
        {
            return CreateBonus(_bonusData.BonusStruct.StorageLive, InteractiveObjectType.ExtraLive, 1).transform;
        }

        public Transform CreateBomb()
        {
            return CreateBonus(_bonusData.BonusStruct.StorageBonusBomb, InteractiveObjectType.Bomb, 1).transform;
        }

        public Transform CreateImmunity()
        {
            return CreateBonus(_bonusData.BonusStruct.StorageBonusImmunity, InteractiveObjectType.Immunitet, 5)
                .transform;
        }

        public Transform CreateSpeedUp()
        {
            return CreateBonus(_bonusData.BonusStruct.StorageBonusSpeedUp, InteractiveObjectType.SpeedUp, 2).transform;
        }

        #endregion


        #region privateMethods

        private static GameObject CreateBonus(GameObject prototype, InteractiveObjectType type, int value)
        {
            var bonus = Object.Instantiate(prototype);
            bonus.name = prototype.name;
            bonus.AddSphereCollider(radius: 1.5f, isTrigger : true)
                .AddBonusView(type: type, value: value);
            return bonus;
        }

        #endregion
    }
}