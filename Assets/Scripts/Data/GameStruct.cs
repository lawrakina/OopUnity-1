using System;
using System.ComponentModel;
using UnityEngine;


namespace Data
{
    [Serializable]
    public sealed class GameStruct
    {
        [SerializeField] private Vector2 _pointZero = Vector2.zero;
        [SerializeField] private float _lenght = 100.0f;
        [SerializeField] private float _widht = 100.0f;
        public int countNeedCoins = 10;
        public int countLive = 3;
        public int countCoins = 0;
        
        [Description("x - StartPoint.X,\ny - StartPoint.Y,\nz - Lendht,\nw - Wight")]
        public Vector4 SizeOfPlatform =>
            new Vector4(_pointZero.x,
                _pointZero.y,
                _lenght,
                _widht);
    }
}