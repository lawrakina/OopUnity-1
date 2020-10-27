using System;
using UnityEngine;


namespace Data
{
    [Serializable]
    public sealed class PlayerStruct
    {
        public GameObject StoragePlayer;
        public Vector3 StartPosition;
        public float speed = 100.0f;
        public BoxFloat Speed { get; set; }
        [HideInInspector] public GameObject Player;
    }
}