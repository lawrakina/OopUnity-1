using System;
using UnityEngine;


namespace Data
{
    [Serializable]
    public class GameStruct
    {
        public GameObject StorageCoin;
        public Vector2 PointZero = Vector2.zero;
        public float Lenght = 50.0f;
        public float Widht = 50.0f;
        public int CountCreateCoints = 10;
        public int CountNeedCoints = 10;
        public int CountCoins = 0;
        public int CountLive = 3;
    }
}