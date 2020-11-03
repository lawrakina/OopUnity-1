using System;
using UnityEngine;


namespace Data
{
    [Serializable]
    public sealed class BonusStruct
    {
        public GameObject StorageCoin;
        public GameObject StorageBonusImmunity;
        public GameObject StorageBonusBomb;
        public GameObject StorageBonusSpeedUp;
        public GameObject StorageLive;

        public int createCountCoins         = 50;
        public int createCountBonusSpeedUp  = 5;
        public int createCountBonusImmunity = 5;
        public int createCountBonusBomb     = 20;
        public int createExtraLive          = 3;
    }
}