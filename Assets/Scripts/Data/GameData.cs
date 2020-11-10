using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Data/GameData")]
    public class GameData : ScriptableObject
    {
        public GameStruct GameStruct;
    }
}