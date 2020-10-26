using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "GameData", menuName = "GameData")]
    public class GameData : ScriptableObject
    {
        public GameStruct GameStruct;
    }
}