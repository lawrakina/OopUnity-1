using System;
using UnityEngine;


namespace Data
{
    [Serializable]
    public class PlayerStruct
    {
        public GameObject StoragePlayer;
        public Vector3 StartPosition;
        [HideInInspector] public GameObject Player;
        public float Speed;
    }
}