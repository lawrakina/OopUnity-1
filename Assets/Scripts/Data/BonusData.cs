using UnityEngine;


namespace Data
{
    [CreateAssetMenu(fileName = "BonusData", menuName = "Data/BonusData")]
    public sealed class BonusData : ScriptableObject
    {
        public BonusStruct BonusStruct;
    }
}