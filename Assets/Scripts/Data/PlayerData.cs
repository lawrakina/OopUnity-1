using Units;
using UnityEngine;


namespace Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData")]
    public class PlayerData : ScriptableObject, IUnit
    {
        // public PlayerStruct PlayerStruct;
        [SerializeField] public GameObject StoragePlayer;
        [SerializeField] public Vector3    StartPosition;
        [SerializeField, Range(0, 200)] private float _speed;
        public float Speed => _speed;
    }
}