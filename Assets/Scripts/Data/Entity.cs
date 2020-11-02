using UnityEngine;


namespace Data
{
    //ссылочные обертки вокруг значимых типов 
    public sealed class UserInput
    {
        public Vector3 InputVector;
    }

    public sealed class BoxInt
    {
        private int _value;
        public delegate void ChangeValue();
        public event ChangeValue EventChange;
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                EventChange?.Invoke();
            }
        }
    }

    public sealed class BoxFloat
    {
        private float _value;
        public delegate void ChangeValue();
        public event ChangeValue EventChangeValue;
        public float Value
        {
            get => _value;
            set
            {
                _value = value;
                EventChangeValue?.Invoke();
            }
        }
    }
}