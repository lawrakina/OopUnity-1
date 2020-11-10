using System;
using Interface;
using Model;
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
        [SerializeField, Range(0, 200)] public float _speed;
        
        public IFloatNotifyPropertyChange Speed { get; set; }

        // private void Awake()
        // {
        //     Speed = new FloatNotifyPropertyChange(_speed);
        //     // Speed.Value = _speed;
        // }
    }
}