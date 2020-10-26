using System;
using UnityEngine;


namespace Data
{
    [Serializable]
    public class PlayerStruct
    {
        public GameObject StoragePlayer;
        public Vector3 StartPosition;
        public float Speed;
        [HideInInspector] public GameObject Player;
    }
}