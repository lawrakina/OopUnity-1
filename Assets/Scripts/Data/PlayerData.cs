using UnityEngine;


namespace Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public PlayerStruct PlayerStruct;
    }
}