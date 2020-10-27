using System;
using Healper;
using UnityEngine;


namespace Data
{
    [Serializable]
    public sealed class GameStruct
    {
        [Header("For Inspector")]
        public GameObject StorageCoin;
        public Vector2 PointZero = Vector2.zero;
        public float Lenght = 50.0f;
        public float Widht = 50.0f;
        public int createCoins = 10;
        public int countNeedCoins = 10;
        public int countLive = 3;
        public int countCoins = 0;
        public BoxInt CountNeedCoins { get; set;}
        public BoxInt CountCoins { get; set;}
        public BoxInt CountLive { get; set;}
    }
}