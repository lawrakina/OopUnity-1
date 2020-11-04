using System;
using Interface;


namespace Model
{
    public class IntIintNotifyPropertyChange : IIntNotifyPropertyChange
    {
        #region Fields

        private int _value;

        #endregion


        #region ClassLiveCycles

        protected IntIintNotifyPropertyChange(int countCoins)
        {
            _value = countCoins;
        }

        #endregion

        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                OnValueChange.Invoke(value);
            }
        }

        public event Action<int> OnValueChange = delegate(int i) { };
    }
}